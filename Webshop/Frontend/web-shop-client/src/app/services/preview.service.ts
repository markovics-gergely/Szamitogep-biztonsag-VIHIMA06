import { Injectable } from '@angular/core';
import { SafeUrl } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root',
})
export class PreviewService {
  /** Url of the image to display */
  private _previewImage: string | SafeUrl | undefined;

  get previewImage() {
    return this._previewImage;
  }
  set previewImage(value: string | SafeUrl | undefined) {
    this._previewImage = value;
  }
}
