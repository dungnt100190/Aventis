import {
    Component,
    Injector
} from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ClassRightModel } from '../models/auth/class-right.model';

export abstract class BaseComponent {
    public titlePage: string;
    protected permissions: ClassRightModel;

    private titleService: Title;

    public constructor(injector: Injector) {
        this.titleService = injector.get(Title);
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    public getTitle(): string {
        return this.titleService.getTitle();
    }
}
