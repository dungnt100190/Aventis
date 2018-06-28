import { ClassRightModel } from './../models/auth/class-right.model';

export function SetClassRight(className) {
    return (target) => {
        Object.defineProperty(target.prototype, 'permissions', { value: new ClassRightModel(className) });
    };
}
