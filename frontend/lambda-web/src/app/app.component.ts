import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule],
  template: `
    <div class="min-h-screen bg-gradient-to-br from-gray-900 to-gray-800 text-white">
      <div class="container mx-auto px-4 py-16">
        <div class="text-center">
          <h1 class="text-6xl font-bold mb-8">Lambda</h1>
          <p class="text-xl text-gray-300 mb-8">
            AI-Powered Educational Problem Generator
          </p>
          <div class="bg-white/10 p-8 rounded-lg backdrop-blur-sm max-w-2xl mx-auto">
            <p class="text-lg mb-4">
              Generate custom problems in mathematics, physics, chemistry and more using advanced AI.
            </p>
            <button class="bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 px-8 rounded-full transition-all">
              Get Started
            </button>
          </div>
        </div>
      </div>
    </div>
    <router-outlet />
  `
})
export class AppComponent {
  title = 'Lambda';
}