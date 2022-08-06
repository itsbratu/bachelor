bits 32

global start        

extern exit , printf , scanf            
import exit msvcrt.dll
import printf msvcrt.dll
import scanf msvcrt.dll     

segment data use32 class=data
    mesaj db "Introduceti dublucuvantul in baza 16 : " , 0
    format db "%x" , 0
    nr dd -1
    bit db -1
    contor dd 0
    mesaj_afisare db "In sirul dat , apar %d secvente de 10" , 0

segment code use32 class=code
    start:
    
        push dword mesaj
        call [printf]
        add esp , 4 
        
        push dword nr
        push dword format
        call [scanf]
        add esp , 4 * 2
        
        mov eax , dword[nr]
        mov ecx , 32
        
        parcurgere:
            xor ebx , ebx 
            shr eax , 1
            adc ebx , 0
            
            cmp ebx , 1
            je might_be
            
            mov bl , 0
            mov byte[bit] , bl
            jmp final
            
            might_be:
                xor edx , edx
                mov dl , byte[bit]
                cmp dl , 0
                je increment
                    
            mov bl , -1
            mov byte[bit] , -1
            jmp final
            
            increment:
                xor edx , edx 
                mov edx , dword[contor]
                inc edx 
                mov dword[contor] , edx
                mov dl , -1
                mov byte[bit] , dl
            final:
        
        loop parcurgere
        
        xor eax , eax 
        mov eax , dword[contor]
        
        push eax 
        push mesaj_afisare 
        call [printf]
        add esp , 4 * 2
        
        
        push    dword 0      
        call    [exit]       
