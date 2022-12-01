import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CaffViewModel, PagerList, PagerModel } from 'models';
import { CaffService } from 'src/app/services/caff.service';
import { LoadingService } from 'src/app/services/loading.service';
import { SnackService } from 'src/app/services/snack.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
})
export class InventoryComponent implements OnInit {
  private _caffs: CaffViewModel[] | undefined;
  private _total: number = 0;
  private _searchForm: FormGroup | undefined;

  constructor(
    private caffService: CaffService,
    private loadingService: LoadingService,
    private userService: UserService,
    private snackService: SnackService,
    private tokenService: TokenService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadingService.isLoading = true;
    this.userService
      .getInventory(environment.default_page_size, environment.default_page)
      .subscribe((data) => {
        this._caffs = data.values;
        this._total = data.total;
        this._caffs.forEach((caff) => {
          this.caffService
            .getImage(caff.coverUrl)
            .subscribe((url) => (caff.safeUrl = url));
        });
      })
      .add(() => (this.loadingService.isLoading = false));
      this._searchForm = this.formBuilder.group({
        search: new FormControl('', [Validators.required, Validators.min(4)]),
      });
  }

  search() {
    if (this._searchForm && this._searchForm.valid) {
      this.loadingService.isLoading = true;
      this._total = 0;
      this.caffService
        .getCaffs(
          environment.default_page_size,
          environment.default_page,
          this._searchForm.get('search')?.value
        )
        .subscribe((data: PagerList<CaffViewModel>) => {
          this._caffs = data.values;
          this._total = data.total;
        })
        .add(() => (this.loadingService.isLoading = false));
    }
  }

  /**
   * Process pager change events
   * @param value Pager changed event
   */
  setPage(value: PagerModel) {
    this.loadingService.isLoading = true;
    this.userService
      .getInventory(value.pageSize, value.page + 1)
      .subscribe((data) => {
        this._caffs = data.values;
        this._total = data.total;
      })
      .add(() => (this.loadingService.isLoading = false));
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
