import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  CaffDetailViewModel,
  CaffViewModel,
  CommentCreateDTO,
  CreateCaffDTO,
  EditCaffDTO,
  PagerList,
  RemoveCommentDTO,
} from 'models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CaffService {
  /** Base url of caff endpoint */
  private _baseUrl = `${environment.baseUrl}/caff`;

  constructor(private http: HttpClient) {}

  /**
   * Send get request for caffs for the browse page
   * @returns List of caffs data for browse page
   */
  public getCaffs(
    pageSize: number,
    pageCount: number,
    search?: string
  ): Observable<PagerList<CaffViewModel>> {
    return this.http.get<PagerList<CaffViewModel>>(this._baseUrl, {
      params: new HttpParams()
        .set('Search', search || '')
        .set('PageSize', pageSize)
        .set('PageCount', pageCount),
    });
  }

  /**
   * Send get request for caff details
   * @returns Caff with detailed informations
   */
  public getCaff(caffId: string): Observable<CaffDetailViewModel> {
    return this.http.get<CaffDetailViewModel>(`${this._baseUrl}/${caffId}`);
  }

  public deleteCaff(id: string): Observable<any> {
    return this.http.delete(`${this._baseUrl}/${id}`);
  }

  public addToCart(id: string): Observable<any> {
    return this.http.post(`${this._baseUrl}/checkout/${id}`, {});
  }

  public downloadCaff(caff: CaffViewModel | CaffDetailViewModel) {
    this.downloadFile(caff.id).subscribe((data) => {
      const downloadURL = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadURL;
      link.download = `${caff.title}.caff`;
      link.click();
    });
  }

  private downloadFile(id: string): Observable<Blob> {
    return this.http.get(`${this._baseUrl}/download/${id}`, {
      responseType: 'blob',
    });
  }

  public createComment(id: string, dto: CommentCreateDTO): Observable<any> {
    return this.http.post(
      `${this._baseUrl}/${id}/comments/add`,
      this.getFormData(dto)
    );
  }

  public deleteComment(id: string, dto: RemoveCommentDTO): Observable<any> {
    return this.http.delete(`${this._baseUrl}/${id}/comments/remove`, {
      body: dto,
    });
  }

  public createCaff(dto: CreateCaffDTO): Observable<string> {
    return this.http.post<string>(this._baseUrl, this.getFormData(dto));
  }

  public editCaff(id: string, dto: EditCaffDTO): Observable<any> {
    return this.http.put(`${this._baseUrl}/${id}`, dto);
  }

  /**
   * Generate form data from object
   * @param obj Object to transform
   * @returns FormData generated
   */
  private getFormData(obj: any): FormData {
    return Object.keys(obj).reduce((formData, key) => {
      formData.append(key, obj[key]);
      return formData;
    }, new FormData());
  }
}
