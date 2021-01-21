usci.module char a = if
  UCA0CTL0  constant usci.ctl0
  UCA0CTL1  constant usci.ctl1
  UCA0BR0   constant usci.br0
  UCA0BR1   constant usci.br1
  UCA0RXBUF constant usci.rxbuf
  UCA0TXBUF constant usci.txbuf
else
  UCB0CTL0  constant usci.ctl0
  UCB0CTL1  constant usci.ctl1
  UCB0BR0   constant usci.br0
  UCB0BR1   constant usci.br1
  UCB0RXBUF constant usci.rxbuf
  UCB0TXBUF constant usci.txbuf
then


: spi-init   ( baud mode -- )
  1 usci.ctl1 setb                      \ disable module
  6 lshift 9 or usci.ctl0 c!            \ set SPI mode, master, sync
  drop 1 usci.br0 c! 0 usci.br1 c!      \ prescaler 1x
  0C0 usci.ctl1 setb                    \ clock = SMCLK
  1 usci.ctl1 clrb ;                    \ enable module

: spi.   usci.ctl0 8 dump ;
: +spi ;
: -spi ;
: >spi>   ( c -- c )
  usci.txbuf c!
  usci.rxbuf c@ ;
