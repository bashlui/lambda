import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface HelloResponse {
  message: string;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
    private apiUrl = 'http://localhost:5188/api';

    constructor(private http: HttpClient) {}

    getHello(): Observable<HelloResponse> {
        return this.http.get<HelloResponse>(`${this.apiUrl}/hello`);
    }
}