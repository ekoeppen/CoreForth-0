$0128 constant FCTL1
$012A constant FCTL2
$012C constant FCTL3

: unlock-flash      $A500 FCTL3 ! ;
: lock-flash        $A510 FCTL3 ! ;

: erase-segment     ( segment -- )
                    dint unlock-flash $A502 FCTL1 !
                    0 swap !
                    $A500 FCTL1 ! lock-flash eint ;

: erase-to-end      ( segment -- )
                    erase-segment ;

: set-flash-clk     ( prescaler -- )
                    $A580 + FCTL2 ! lock-flash ;

: +flash-write      unlock-flash   $A540 FCTL1 ! ;
