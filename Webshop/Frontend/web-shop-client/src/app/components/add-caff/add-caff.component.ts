import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateCaffDTO } from 'models';

@Component({
  selector: 'app-add-caff',
  templateUrl: './add-caff.component.html',
  styleUrls: ['./add-caff.component.scss'],
})
export class AddCaffComponent implements OnInit {
  private _form: FormGroup | undefined;

  constructor(
    public dialogRef: MatDialogRef<AddCaffComponent>,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this._form = this.formBuilder.group({
      title: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
      ]),
      description: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
      ]),
      caff: new FormControl(undefined, Validators.required),
    });
  }

  onSubmit() {
    const dto: CreateCaffDTO = {
      title: this._form?.get('title')?.value,
      description: this._form?.get('description')?.value,
      caff: this._form?.get('caff')?.value,
    };
    this.dialogRef.close(dto);
  }

  exit() {
    this.dialogRef.close();
  }

  addCaff(event: Event) {
    const files = (event.target as HTMLInputElement)?.files;
    if (files?.length) {
      this._form?.controls['caff'].setValue(files[0]);
    }
  }

  removeCaff() {
    this._form?.controls['caff'].setValue(undefined);
  }

  get filename(): string {
    return this._form?.get('caff')?.value?.name;
  }
  get form() {
    return this._form;
  }
}
