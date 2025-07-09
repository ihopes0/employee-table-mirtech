import { Component, Input } from '@angular/core'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-confirm-modal',
  standalone: false,
  templateUrl: './confirm-modal.component.html',
  // styleUrls: ['./confirm-modal.component.css'],
})
export class ConfirmModalComponent {
  @Input() title = 'Подтверждение'
  @Input() message = 'Вы уверены?'
  @Input() btnOkText = 'Ок'
  @Input() btnCancelText = 'Отмена'

  constructor(public activeModal: NgbActiveModal) {}

  confirm(): void {
    this.activeModal.close(true)
  }

  decline(): void {
    this.activeModal.dismiss(false)
  }
}
