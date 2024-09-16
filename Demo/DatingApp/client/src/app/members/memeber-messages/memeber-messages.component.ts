import { Component, inject, input, OnInit } from '@angular/core';
import { Message } from '../../_models/message';
import { MessageService } from '../../_services/message.service';

@Component({
  selector: 'app-memeber-messages',
  standalone: true,
  imports: [],
  templateUrl: './memeber-messages.component.html',
  styleUrl: './memeber-messages.component.css'
})
export class MemeberMessagesComponent implements OnInit {
  private messageService = inject(MessageService);
  username = input.required<string>();
  messages: Message[] = [];

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.messageService.getMessageThread(this.username()).subscribe({
      next: messages => this.messages = messages
    });
  }
}
