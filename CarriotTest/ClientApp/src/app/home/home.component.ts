import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'SignalRClient';
  private hubConnectionBuilder!: HubConnection;
  tempLogs: any[] = [];
  warnings: any[] = [];

  constructor() { }
  ngOnInit(): void {
    this.hubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7065/notify').configureLogging(LogLevel.Information).build();
    this.hubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
    this.hubConnectionBuilder.on('SendTempLog', (result: any) => {
      this.tempLogs.push(result);
  
    });
    this.hubConnectionBuilder.on('SendWarning', (result: any) => {
      this.warnings.push(result);
    });
  }
}
