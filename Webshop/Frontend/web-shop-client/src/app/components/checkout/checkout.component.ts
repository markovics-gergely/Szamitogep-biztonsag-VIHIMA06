import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CaffViewModel, PagerModel } from 'models';
import { CaffService } from 'src/app/services/caff.service';
import { LoadingService } from 'src/app/services/loading.service';
import { SnackService } from 'src/app/services/snack.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
  private _caffs: CaffViewModel[] | undefined;
  private _total: number = 0;

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
    this.caffService
      .getCaffs(environment.default_page_size, environment.default_page)
      .subscribe((data) => {
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
    this.caffService
      .getCaffs(value.pageSize, value.page + 1)
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
}
