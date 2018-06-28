export class TreeNavModel implements ITreeNavModel {
    id: number;
    text: string;
    icon: string;
    content: string;
    constructor(data?: ITreeNavModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }
}


export class ITreeNavModel {
    id: number;
    text: string;
    icon: string;
    content: string;
}