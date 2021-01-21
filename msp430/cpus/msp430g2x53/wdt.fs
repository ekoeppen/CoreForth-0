$0120 constant WDTCTL

: disable-wdt   $5A80 WDTCTL ! ;
: +wdt-ie       1 IE1 bis! ;
: -wdt-ie       1 IE1 bic! ;
: -wdt-ifg      1 IFG1 bic! ;
: wdt-ifg?      1 IFG1 bit@ ;
: wdt/1s        $5A1C WDTCTL ! ;
: wdt/250ms     $5A1D WDTCTL ! ;
