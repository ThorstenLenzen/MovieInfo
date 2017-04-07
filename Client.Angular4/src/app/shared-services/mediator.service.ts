import { Injectable } from '@angular/core';

export type SubscriptionCallback = (message: any) => void;

@Injectable()
export class MediatorService {


  constructor() { }

  public publish(messageType: string, message: any): void {

  }

  public subscribe(messageType: string, callback: SubscriptionCallback): void {

  }

}
