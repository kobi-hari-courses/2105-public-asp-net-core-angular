import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-colored-text',
  templateUrl: './colored-text.component.html',
  styleUrls: ['./colored-text.component.css']
})
export class ColoredTextComponent implements OnInit {
    @Input()
    color: string = 'blue';

  constructor() { }

  ngOnInit(): void {
  }

}
