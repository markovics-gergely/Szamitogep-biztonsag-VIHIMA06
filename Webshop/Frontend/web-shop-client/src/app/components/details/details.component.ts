import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CaffDetailViewModel, CommentViewModel } from 'models';
import { CaffService } from 'src/app/services/caff.service';
import { LoadingService } from 'src/app/services/loading.service';
import { PreviewService } from 'src/app/services/preview.service';
import { SnackService } from 'src/app/services/snack.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  private _caff: CaffDetailViewModel | undefined;
  private _comments: CommentViewModel[] | undefined;
  private _commentForm: FormGroup | undefined;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private loadingService: LoadingService,
    private userService: UserService,
    private snackService: SnackService,
    private tokenService: TokenService,
    private caffService: CaffService,
    private previewService: PreviewService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadingService.isLoading = true;
    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.caffService
          .getComments(params['id'])
          .subscribe((comments) => (this._comments = comments));
        this.caffService
          .getCaff(params['id'])
          .subscribe((caff) => (this._caff = caff))
          .add(() => (this.loadingService.isLoading = false));
      }
    });
    this._commentForm = this.formBuilder.group({
      text: new FormControl('', Validators.required),
    });
  }

  deleteCaff(caff: CaffDetailViewModel | undefined, event: Event) {}

  downloadCaff(caff: CaffDetailViewModel | undefined, event: Event) {}
  onSubmit() {}

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
  /**
   * Get current active route
   */
  get activeMenu() {
    return this.router.url.slice(1).split('/')[0];
  }
  get caff() {
    return this._caff;
  }
  get comments() {
    return this._comments;
  }
  get commentForm() {
    return this._commentForm;
  }
}
