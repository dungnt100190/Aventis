import { MenuModel } from './../models';

export const MenusMock: MenuModel[] = [
    {
        id: '1',
        name: 'Menü',
        items: [{
            id: '1_1',
            name: 'person',
            sort: 1,
            iconSrc: 'assets/icon/item-menu.png',
            url: '/persons',
        }
            , {
            id: '1_2',
            name: 'Dossier',
            iconSrc: 'assets/icon/item-menu.png',
            url: '/dossier',
            sort: 2
        }, {
            id: '1_3',
            name: 'Pendenzen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '/pendenzen',
            sort: 3
        }]
    },
    {
        id: '2',
        name: 'Aktionen',
        items: [{
            id: '2_1',
            name: 'Neue Pendenz',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '2_2',
            name: 'Aktion 2',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '2_3',
            name: 'Aktion 3',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }]
    },
    {
        id: '3',
        name: 'Zuletzt geöffnet',
        items: [{
            id: '3_1',
            name: 'Zuletzt geöffnet 1',
            iconSrc: 'assets/icon/item-menu.png',
            items: [{
                id: '3_1_1',
                name: 'Mohamed Michael',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 1
            },
            {
                id: '3_1_2',
                name: 'Murati, Khaled',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 2
            },
            {
                id: '3_1_3',
                name: 'Casanova, Nelly',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 3
            }]
        }, {
            id: '3_2',
            name: 'Zuletzt geöffnet 2',
            iconSrc: 'assets/icon/item-menu.png',
            items: [{
                id: '3_2_1',
                name: 'Zuletzt geöffnet 1',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 1
            }, {
                id: '3_2_2',
                name: 'Zuletzt geöffnet 2',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 2
            },
            {
                id: '3_2_3',
                name: 'Zuletzt geöffnet 3',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 3
            }]
        }, {
            id: '3_3',
            name: 'Zuletzt geöffnet 3',
            iconSrc: 'assets/icon/item-menu.png',
            items: [{
                id: '3_3_1',
                name: 'Zuletzt geöffnet 1',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 1
            }, {
                id: '3_3_2',
                name: 'Zuletzt geöffnet 2',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 2
            },
            {
                id: '3_3_3',
                name: 'Zuletzt geöffnet 3',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 3
            }]
        }]
    }
];
