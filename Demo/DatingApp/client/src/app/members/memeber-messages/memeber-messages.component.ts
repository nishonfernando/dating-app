import { Component, inject, input, OnInit } from '@angular/core';
import { Message } from '../../_models/message';
import { MessageService } from '../../_services/message.service';
import { TimeagoModule } from 'ngx-timeago';

@Component({
  selector: 'app-memeber-messages',
  standalone: true,
  imports: [TimeagoModule],
  templateUrl: './memeber-messages.component.html',
  styleUrl: './memeber-messages.component.css'
})
export class MemeberMessagesComponent implements OnInit {
  private messageService = inject(MessageService);
  username = input.required<string>();
  messages = input.required<Message[]>();

  ngOnInit(): void {
  }
}
