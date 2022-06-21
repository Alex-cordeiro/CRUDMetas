export class LoginResponse {
    public authenticated!: boolean;
    public created!: Date;
    public expiration!: Date;
    public accessToken!: string;
    public refreshToken!: string;
}