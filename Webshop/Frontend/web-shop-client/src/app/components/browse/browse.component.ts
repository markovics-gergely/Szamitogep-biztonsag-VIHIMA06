import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import {
  CaffViewModel,
  CreateCaffDTO,
  EditCaffDTO,
  PagerList,
  PagerModel,
} from 'models';
import { AddCaffComponent } from 'src/app/components/add-caff/add-caff.component';
import { CaffService } from 'src/app/services/caff.service';
import { ConfirmService } from 'src/app/services/confirm.service';
import { LoadingService } from 'src/app/services/loading.service';
import { SnackService } from 'src/app/services/snack.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';
import { EditCaffComponent } from '../edit-caff/edit-caff.component';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.scss'],
})
export class BrowseComponent implements OnInit {
  private _caffs: CaffViewModel[] | undefined;
  private _total: number = 0;
  private _searchForm: FormGroup | undefined;

  constructor(
    private caffService: CaffService,
    private loadingService: LoadingService,
    private userService: UserService,
    private snackService: SnackService,
    private tokenService: TokenService,
    private formBuilder: FormBuilder,
    private confirmService: ConfirmService,
    private dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadingService.isLoading = true;
    this.caffService
      .getCaffs(environment.default_page_size, environment.default_page)
      .subscribe((data: PagerList<CaffViewModel>) => {
        this._caffs = data.values;
        this._total = data.total;
      })
      .add(() => {
        this.loadingService.isLoading = false;
      });
    this._searchForm = this.formBuilder.group({
      search: new FormControl('', [Validators.required, Validators.min(4)]),
    });
  }

  search() {
    this.loadingService.isLoading = true;
    const search = this._searchForm?.valid
      ? this._searchForm.get('search')?.value
      : undefined;

    this.loadingService.isLoading = true;
    this._total = 0;
    this.caffService
      .getCaffs(environment.default_page_size, environment.default_page, search)
      .subscribe((data: PagerList<CaffViewModel>) => {
        this._caffs = data.values;
        this._total = data.total;
      })
      .add(() => (this.loadingService.isLoading = false));
  }

  /**
   * Process pager change events
   * @param value Pager changed event
   */
  setPage(value: PagerModel) {
    this.loadingService.isLoading = true;
    const search = this._searchForm?.valid
      ? this._searchForm.get('search')?.value
      : undefined;

    this.caffService
      .getCaffs(value.pageSize, value.page + 1, search)
      .subscribe((data: PagerList<CaffViewModel>) => {
        this._caffs = data.values;
        this._total = data.total;
      })
      .add(() => (this.loadingService.isLoading = false));
  }

  /**
   * Delete caff
   * @param c Caff to delete
   * @param event Selection event
   */
  deleteCaff(c: CaffViewModel | undefined, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService
      .confirm('Delete caff', `Are you sure you want to delete ${c?.title}?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService
            .deleteCaff(c!.id)
            .subscribe(() => {
              this.snackService.openSnackBar(
                'Successfully deleted caff!',
                'OK'
              );
              this._total--;
              this._caffs = this._caffs?.filter((caff) => caff.id !== c?.id);
            })
            .add(() => (this.loadingService.isLoading = false));
        }
      });
  }

  createCaff() {
    const dialogRef: MatDialogRef<AddCaffComponent, CreateCaffDTO> =
      this.dialog.open(AddCaffComponent, {
        width: '60%',
      });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadingService.isLoading = true;
        this.caffService
          .createCaff(result)
          .subscribe((result) => {
            this.router.navigate(['browse', result]);
            this.snackService.openSnackBar('Caff successfully created!', 'OK');
          })
          .add(() => (this.loadingService.isLoading = false));
      }
    });
  }

  editCaff(caff: CaffViewModel, event: Event) {
    event.stopImmediatePropagation();
    const dialogRef: MatDialogRef<EditCaffComponent, EditCaffDTO> =
      this.dialog.open(EditCaffComponent, {
        width: '60%',
        data: caff,
      });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadingService.isLoading = true;
        this.caffService
          .editCaff(caff.id, result)
          .subscribe(() => {
            caff.title = result.title;
            this.snackService.openSnackBar('Caff successfully edited!', 'OK');
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
  addCaff(c: CaffViewModel | undefined, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService
      .confirm('Add caff', `Are you sure you want to add ${c?.title}?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService
            .addToCart(c!.id)
            .subscribe(() => {
              this.snackService.openSnackBar('Successfully added caff!', 'OK');
              this._total--;
              this._caffs = this._caffs?.filter((caff) => caff.id !== c?.id);
            })
            .add(() => (this.loadingService.isLoading = false));
        }
      });
  }

  isOwnCaff(c: CaffViewModel) {
    return c.uploader?.id === this.userId;
  }

  /**
   * Getter for user administrator status
   */
  get isAdmin(): boolean {
    return this.tokenService.role === 'Admin';
  }
  get caffs() {
    return this._caffs;
  }
  get total() {
    return this._total;
  }
  get userId() {
    return this.userService.actualUserId;
  }
  get searchForm() {
    return this._searchForm;
  }
}
