#include <18F4620.h>
#device ADC=16

#FUSES WDT                      //Watch Dog Timer
#FUSES WDT1                     //Watch Dog Timer uses 1:1 Postscale
#FUSES NOBROWNOUT               //No brownout reset
#FUSES NOLVP                    //No low voltage prgming, B3(PIC16) or B5(PIC18) used for I/O
#FUSES NOXINST                  //Extended set extension and Indexed Addressing mode disabled (Legacy mode)

#use delay(crystal=20000000)

