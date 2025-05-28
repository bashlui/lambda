import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- Importa esto
import { JsonPipe } from '@angular/common';     // <-- Y esto también
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, JsonPipe], // <-- Agrégalo aquí
  template: `
    <div style="padding: 20px; font-family: Arial, sans-serif;">
      <h1>Lambda Project - Connection Test</h1>
      
      <div style="margin: 20px 0;">
        <h2>Backend Connection Status:</h2>
        <div [style.color]="connectionStatus === 'Connected' ? 'green' : 'red'">
          {{ connectionStatus }}
        </div>
      </div>

      <div style="margin: 20px 0;">
        <button (click)="testConnection()" 
                style="padding: 10px 20px; background: #007bff; color: white; border: none; border-radius: 4px; cursor: pointer;">
          Test Connection to localhost:5188
        </button>
      </div>

      <div *ngIf="responseData" style="margin: 20px 0;">
        <h3>Backend Response:</h3>
        <pre style="background: #f5f5f5; padding: 10px; border-radius: 4px;">{{ responseData | json }}</pre>
      </div>

      <div style="margin: 20px 0;">
        <h3>Configuration:</h3>
        <p><strong>Frontend URL:</strong> http://localhost:4200</p>
        <p><strong>Backend URL:</strong> {{ backendUrl }}</p>
        <p><strong>API URL:</strong> {{ apiUrl }}</p>
      </div>
    </div>
  `
})
export class AppComponent implements OnInit {
  title = 'lambda-frontend';
  connectionStatus = 'Testing...';
  responseData: any = null;
  backendUrl = environment.backendUrl;
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.testConnection();
  }

  testConnection() {
    this.connectionStatus = 'Testing...';
    this.responseData = null;

    // Test direct connection to localhost:5188
    this.http.get(`${environment.apiUrl}/test`).subscribe({
      next: (response) => {
        this.connectionStatus = 'Connected';
        this.responseData = response;
        console.log('Backend connection successful:', response);
      },
      error: (error) => {
        this.connectionStatus = 'Failed';
        this.responseData = { error: error.message };
        console.error('Backend connection failed:', error);
      }
    });
  }
}
