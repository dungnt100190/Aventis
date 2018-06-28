import {
    Component,
    Input,
    Output,
    EventEmitter,
    ChangeDetectionStrategy,
} from '@angular/core';
import { DossierFilterModel } from '../../shared/models';

@Component({
    selector: 'dossier-nav-filters',
    templateUrl: './nav-filters.component.html',
    styleUrls: ['./nav-filters.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class NavFiltersComponent {
    @Input() filter: DossierFilterModel;

    @Output() ValuedActive: EventEmitter<any> = new EventEmitter();
    @Output() ValuedClosed: EventEmitter<any> = new EventEmitter();
    @Output() ValuedArchived: EventEmitter<any> = new EventEmitter();
    @Output() ValuedIncludeGroup: EventEmitter<any> = new EventEmitter();
    @Output() ValuedIncludeGuest: EventEmitter<any> = new EventEmitter();
    @Output() ValuedIncludeTasks: EventEmitter<any> = new EventEmitter();

    constructor() { }

    onFiltersChanged = {
        ckbActive: (e) => {
            this.ValuedActive.emit(e);
        },
        ckbClosed: (e) => {
            this.ValuedClosed.emit(e);
        },
        ckbArchived: (e) => {
            this.ValuedArchived.emit(e);
        },
        ckbIncludeGroup: (e) => {
            this.ValuedIncludeGroup.emit(e);
        },
        ckbIncludeGuest: (e) => {
            this.ValuedIncludeGuest.emit(e);
        },
        ckbIncludeTasks: (e) => {
            this.ValuedIncludeTasks.emit(e);
        }
    };
}
