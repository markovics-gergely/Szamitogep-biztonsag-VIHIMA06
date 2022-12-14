import { Injectable } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackService {
  /** Snackbar duration in seconds */
  private duration: number = 5;
  private hPosition: MatSnackBarHorizontalPosition = 'end';
  private vPosition: MatSnackBarVerticalPosition = 'bottom';

  constructor(private snackBar: MatSnackBar) {}

  /**
   * Display a snackbar wih the given text
   * @param message Message to display
   * @param action Display text of the button
   */
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: this.duration * 1000,
      horizontalPosition: this.hPosition,
      verticalPosition: this.vPosition,
      panelClass: 'snack-class',
    });
  }
}
