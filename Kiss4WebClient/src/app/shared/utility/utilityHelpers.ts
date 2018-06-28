import { ElementRef } from '@angular/core';
import { custom } from 'devextreme/ui/dialog';

const typeCache: { [label: string]: boolean } = {};

type Predicate = (oldValues: Array<any>, newValues: Array<any>) => boolean;

/**
 * This function coerces a string into a string literal type.
 * Using tagged union types in TypeScript 2.0, this enables
 * powerful typechecking of our reducers.
 *
 * Since every action label passes through this function it
 * is a good place to ensure all of our action labels are unique.
 *
 * @param label
 */
export function type<T>(label: T | ''): T {
  if (typeCache[<string>label]) {
    throw new Error(`Action type "${label}" is not unqiue"`);
  }

  typeCache[<string>label] = true;

  return <T>label;
}

/**
 * Runs through every condition, compares new and old values and returns true/false depends on condition state.
 * This is used to distinct if two observable values have changed.
 *
 * @param oldValues
 * @param newValues
 * @param conditions
 */
export function distinctChanges(oldValues: Array<any>, newValues: Array<any>, conditions: Predicate[]): boolean {
  if (conditions.every(cond => cond(oldValues, newValues))) { return false; }
  return true;
}

/**
 * Returns true if the given value is type of Object
 *
 * @param val
 */
export function isObject(val: any) {
  if (val === null) { return false; }

  return ((typeof val === 'function') || (typeof val === 'object'));
}

/**
 * Capitalizes the first character in given string
 *
 * @param s
 */
export function capitalize(s: string) {
  if (!s || typeof s !== 'string') { return s; }
  return s && s[0].toUpperCase() + s.slice(1);
}

/**
 * Uncapitalizes the first character in given string
 *
 * @param s
 */
export function uncapitalize(s: string) {
  if (!s || typeof s !== 'string') { return s; }
  return s && s[0].toLowerCase() + s.slice(1);
}

/**
 * Flattens multi dimensional object into one level deep
 *
 * @param obj
 * @param preservePath
 */
export function flattenObject(ob: any, preservePath: boolean = false): any {
  const toReturn = {};

  for (const i in ob) {
    if (!ob.hasOwnProperty(i)) { continue; }

    if ((typeof ob[i]) === 'object') {
      const flatObject = flattenObject(ob[i], preservePath);
      for (const x in flatObject) {
        if (!flatObject.hasOwnProperty(x)) { continue; }

        const path = preservePath ? (i + '.' + x) : x;

        toReturn[path] = flatObject[x];
      }
    } else { toReturn[i] = ob[i]; }
  }

  return toReturn;
}

/**
 * Returns formated date based on given culture
 *
 * @param dateString
 * @param culture
 */
export function localeDateString(dateString: string, culture: string = 'en-EN'): string {
  const date = new Date(dateString);
  return date.toLocaleDateString(culture);
}

/**
 *
 * @param array is array
 * @param item is object
 * @param prop
 */
export function mergeArrayObject(array, item, prop) {
  const reduced = array.find(a => a[prop] === item[prop]);
  if (reduced) { return array; } else {
    return array.concat([item]);
  }
}

/**
 *
 * @param array
 * @param item
 * @param prop
 */
export function spliceObjectArray(array, item, prop) {
  // get index of object with id
  const removeIndex = array.map(function (i) { return item[prop]; }).indexOf(item[prop]);
  if (removeIndex !== -1) { array.splice(removeIndex, 1); }
  return array;
}

/**
 *
 * @param a
 * @param b
 */
export function sortArrayObject(arr1, arr2) {
  return function compare(a, b) {
    if (a.id < b.id) {
      return -1;
    }
    if (a.id > b.id) {
      return 1;
    }
    return 0;
  };
}

export namespace browserFunction {
  /**
   *
   * @param event
   */
  export function getToggleSelector(event: any): any {
    let elToggleNav: ElementRef;
    const path = event.path;
    if (path !== undefined) {
      // for chorme
      const elheader = path.find(item => item.className === 'header-container');
      elToggleNav = elheader.children.item(2);
    } else {
      // fix for firefox
      elToggleNav = event.target.offsetParent.children.item(0).children.item(2);
    }
    return elToggleNav;
  }
}

/**
 *
 * @param jsonString string JSON parse
 */
export function tryParseJSON(jsonString) {
  // tslint:disable-next-line:curly
  if (!jsonString) return false;
  try {
    const ob = JSON.parse(jsonString);
    if (ob && typeof ob === 'object') {
      return ob;
    }
  } catch (e) { }
  return false;
};

export const Dialog = {
  confirm: (title?: string, message?: string) => {
    return custom(<any>{
      title: title || 'confirm',
      showTitle: title ? true : false,
      message: message || '',
      buttons: [
        {
          text: 'Yes', onClick: () => {
            return true;
          },
          focusStateEnabled: false
        },
        {
          text: 'No', onClick: () => {
            return false;
          },
          onInitialized: (e) => { setTimeout(() => { e.component.focus(); }, 200); }
        }
      ]
    }).show();
  },
  alert: (messages, title?: string) => {
    let message = '';
    if (typeof (messages) === 'string') { message = messages; } else if (Array.isArray(messages)) { message = messages.join('<br/>'); }
    return custom(<any>{
      title: title,
      showTitle: title ? true : false,
      message: message,
      buttons: [{
        text: 'Ok', onClick: () => {
          return true;
        }
      }]
    }).show();
  }
};

export function tryParseJwt(token?: any) {
  if (!token) { return null; }
  try {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(window.atob(base64));
  } catch (e) { }
  return null;
};

export function tryMapPathApi(pathApi?: any, urlPath?: string): string {
  if (!pathApi) { return ''; }
  try {
    const url = urlPath || '';
    let result = `${url}?`;
    for (const property in pathApi) {
      if (pathApi.hasOwnProperty(property)) {
        result += `${property}=${(<any>pathApi)[property]}&`;
      }
    }
    result = result.slice(0, -1);
    return result;
  } catch (e) { }
  return '';
}

export function clearCache(): void {
  localStorage.clear();
}
