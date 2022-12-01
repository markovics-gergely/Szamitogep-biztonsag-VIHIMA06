import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CaffDetailViewModel, CaffViewModel, EditCaffDTO } from 'models';
import { CaffService } from 'src/app/services/caff.service';

@Component({
  selector: 'app-edit-caff',
  templateUrl: './edit-caff.component.html',
  styleUrls: ['./edit-caff.component.scss'],
})
export class EditCaffComponent implements OnInit {
  private _form: FormGroup | undefined;

  constructor(
    public dialogRef: MatDialogRef<EditCaffComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CaffViewModel | CaffDetailViewModel,
    private formBuilder: FormBuilder,
    private caffService: CaffService
  ) {}

  ngOnInit(): void {
    this.caffService.getCaff(this.data.id).subscribe((caff) => {
      this._form = this.formBuilder.group({
        title: new FormControl(caff.title, [
          Validators.required,
          Validators.minLength(4),
        ]),
        description: new FormControl(caff.description, [
          Validators.required,
          Validators.minLength(4),
        ]),
      });
    });
  }

  onSubmit() {
    const dto: EditCaffDTO = {
      title: this._form?.get('title')?.value,
      description: this._form?.get('description')?.value,
    };
    this.dialogRef.close(dto);
  }

  exit() {
    this.dialogRef.close();
  }

  get form() {
    return this._form;
  }
}
