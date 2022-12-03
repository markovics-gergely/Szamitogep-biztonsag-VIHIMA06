import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { CaffDetailViewModel, CommentViewModel, EditCaffDTO } from 'models';
import { CaffService } from 'src/app/services/caff.service';
import { ConfirmService } from 'src/app/services/confirm.service';
import { LoadingService } from 'src/app/services/loading.service';
import { PreviewService } from 'src/app/services/preview.service';
import { SnackService } from 'src/app/services/snack.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';
import { EditCaffComponent } from '../edit-caff/edit-caff.component';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  private _caff: CaffDetailViewModel | undefined;
  private _commentForm: FormGroup | undefined;
  private _actualId: number = 0;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private loadingService: LoadingService,
    private userService: UserService,
    private snackService: SnackService,
    private tokenService: TokenService,
    private caffService: CaffService,
    private previewService: PreviewService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog,
    private confirmService: ConfirmService
  ) {}

  ngOnInit(): void {
    this.loadingService.isLoading = true;
    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.caffService
          .getCaff(params['id'])
          .subscribe((caff) => {
            this._caff = caff;
            setTimeout(
              () => this.setNextId(),
              this.ciffs && this.ciffs[this._actualId].duration
            );
          })
          .add(() => (this.loadingService.isLoading = false));
      }
    });
    this._commentForm = this.formBuilder.group({
      text: new FormControl('', Validators.required),
    });
  }

  deleteCaff(caff: CaffDetailViewModel | undefined, event: Event) {
    this.confirmService
      .confirm('Delete caff', `Are you sure you want to delete ${caff?.title}?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService
            .deleteCaff(caff!.id)
            .subscribe(() => {
              this.snackService.openSnackBar(
                'Successfully deleted caff!',
                'OK'
              );
              this.router.navigate([`/${this.activeMenu}`]);
            })
            .add(() => (this.loadingService.isLoading = false));
        }
      });
  }

  /**
   * Add caff to cart
   * @param c Caff to add
   * @param event Selection event
   */
  addCaff(c: CaffDetailViewModel | undefined, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService
      .confirm('Add caff', `Are you sure you want to add ${c?.title}?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService
            .addToCart(c!.id)
            .subscribe(() => {
              this.router.navigate(['inventory', c?.id]);
              this.snackService.openSnackBar('Successfully added caff!', 'OK');
            })
            .add(() => (this.loadingService.isLoading = false));
        }
      });
  }

  /**
   * Remove comment
   * @param c Comment to remove
   * @param event Selection event
   */
  removeComment(c: CommentViewModel, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService
      .confirm('Remove comment', `Are you sure you want to remove '${c.text}'?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService
            .deleteComment(this._caff?.id || '', { commentId: c.id })
            .subscribe(() => {
              if (this._caff) {
                this._caff.comments = this._caff?.comments.filter(
                  (co) => co.id !== c.id
                );
              }
              this.snackService.openSnackBar(
                'Successfully removed comment!',
                'OK'
              );
            })
            .add(() => (this.loadingService.isLoading = false));
        }
      });
  }

  addComment() {
    if (this._commentForm && this._commentForm.valid) {
      this.caffService
        .createComment(this._caff!.id, {
          text: this._commentForm.get('text')?.value,
        })
        .subscribe(() => {
          this._commentForm?.reset();
          this.caffService.getCaff(this._caff?.id || '').subscribe((c) => {
            if (this._caff) {
              this._caff.comments = c.comments;
            }
          });
        })
        .add(() => (this.loadingService.isLoading = false));
    }
  }

  editCaff(event: Event) {
    event.stopImmediatePropagation();
    const dialogRef: MatDialogRef<EditCaffComponent, EditCaffDTO> =
      this.dialog.open(EditCaffComponent, {
        width: '60%',
        data: this.caff,
      });
    dialogRef.afterClosed().subscribe((result) => {
      if (result && this.caff) {
        this.loadingService.isLoading = true;
        this.caffService
          .editCaff(this.caff.id, result)
          .subscribe(() => {
            if (this.caff) {
              this.caff.title = result.title;
              this.caff.description = result.description;
            }
            this.snackService.openSnackBar('Caff successfully edited!', 'OK');
          })
          .add(() => (this.loadingService.isLoading = false));
      }
    });
  }

  /**
   * Open preview page with the selected image
   * @param preview Url of selected image
   */
  preview(preview: string) {
    this.previewService.previewImage = preview;
  }

  backToList() {
    this.router.navigate([`/${this.activeMenu}`]);
  }

  downloadCaff(event: Event) {
    event.stopImmediatePropagation();
    if (this._caff) {
      this.caffService.downloadCaff(this._caff);
    }
  }

  ownComment(c: CommentViewModel) {
    return this.userService.actualUserId === c.commenter.id;
  }

  /**
   * Getter for user administrator status
   */
  get isAdmin(): boolean {
    return this.tokenService.role === 'Admin';
  }

  /**
   * Get current active route
   */
  get activeMenu() {
    return this.router.url.slice(1).split('/')[0];
  }
  get ownCaff() {
    return this.userService.actualUserId === this._caff?.uploader.id;
  }
  get caff() {
    return this._caff;
  }
  get comments() {
    return this._caff?.comments;
  }
  get commentForm() {
    return this._commentForm;
  }
  get token() {
    return this.tokenService.accessToken;
  }
  get ciffs() {
    return this._caff?.ciffs;
  }
  get actualCiff() {
    return this.ciffs && this.ciffs[this._actualId];
  }

  setNextId() {
    if (this.ciffs && this.ciffs.length) {
      this._actualId =
        this._actualId >= this.ciffs.length - 1 ? 0 : this._actualId + 1;
      setTimeout(() => this.setNextId(), this.ciffs[this._actualId].duration);
    }
  }
}
