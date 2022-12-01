import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PreviewService {
  /** Url of the image to display */
  private _previewImage: string | undefined;

  get previewImage() {
    return this._previewImage;
  }
  set previewImage(value: string | undefined) {
    this._previewImage = value;
  }
}
