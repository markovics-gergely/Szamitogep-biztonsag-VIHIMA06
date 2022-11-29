import { Component, OnInit } from '@angular/core';
import { CaffViewModel, PagerModel } from 'models';
import { CaffService } from 'src/app/services/caff.service';
import { ConfirmService } from 'src/app/services/confirm.service';
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
    private confirmService: ConfirmService
  ) { }

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
   * Remove caff
   * @param c Caff to remove
   * @param event Selection event
   */
  deleteCaff(c: CaffViewModel | undefined, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService.confirm('Remove caff', `Are you sure you want to remove ${c?.title} from the cart?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService.removeFromCart(c!.id)
            .subscribe(() => {
              this.snackService.openSnackBar('Successfully removed caff!', 'OK');
              this._total--;
              this._caffs = this._caffs?.filter((caff) => caff.id !== c?.id);
            })
            .add(() => this.loadingService.isLoading = false);
        }
      })
  }

  /**
   * Add caff to cart
   * @param c Caff to add
   * @param event Selection event
   */
  addCaff(c: CaffViewModel | undefined, event: Event) {
    event.stopImmediatePropagation();
    this.confirmService.confirm('Add caff', `Are you sure you want to add ${c?.title}?`)
      .subscribe((result: boolean) => {
        if (result) {
          this.caffService.addToCart(c!.id)
            .subscribe(() => {
              this.snackService.openSnackBar('Successfully added caff!', 'OK');
              this._total--;
              this._caffs = this._caffs?.filter((caff) => caff.id !== c?.id);
            })
            .add(() => this.loadingService.isLoading = false)
        }
      })
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
}
