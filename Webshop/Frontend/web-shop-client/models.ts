export interface LoginUserDTO {
    username: string;
    password: string;
    grant_type?: string;
    client_id?: string;
    client_secret?: string;
    scope?: string;
}

export interface LoginUserResponse {
    access_token: string,
    refresh_token: string,
    detail: string,
    expires_in: number
}

export interface RegisterUserDTO {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmedPassword: string;
}

export interface EditUserRoleDTO {
    id: string;
    role: string;
}

export interface UserMiniViewModel {
    id: string;
    userName: string;
}

export interface ProfileViewModel {
    userName: string;
    name: string;
    email: string;
    role?: string;
}

export interface FullProfileViewModel {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    role?: string;
}

export interface PagerModel {
    page: number;
    pageSize: number;
}

export interface UserNameViewModel {
    id: string;
    userName: string;
}

export interface PagerList<T> {
    total: number;
    values: T[];
}

export interface ConfigViewModel {
    maxUploadSize: number;
    maxUploadCount: number;
}