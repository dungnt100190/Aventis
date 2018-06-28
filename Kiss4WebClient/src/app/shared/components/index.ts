import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PipesModule } from '../pipes';
import { SpinnerComponent } from './spinner/spinner.component';

export const COMPONENTS = [
  SpinnerComponent,
];

@NgModule({
  imports: [
    CommonModule,
    PipesModule
  ],
  declarations: [SpinnerComponent],
  exports: [SpinnerComponent],
})
export class ComponentsModule { }
