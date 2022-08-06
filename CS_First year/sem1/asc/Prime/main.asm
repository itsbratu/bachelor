bits 32

global start        

extern exit , printf , scanf              
import exit msvcrt.dll
import printf msvcrt.dll
import scanf msvcrt.dll    
                         

segment data use32 class=data
    afisare1 db "Va rugam introduceti primul numar : " , 0 
    afisare2 db "Va rugam introduceti al doilea numar : " , 0
    adevarat db "Cele doua numere sunt prime intre ele ! " , 0
    fals db "Cele doua numere nu sunt prime intre ele ! " , 0 
    format db "%d" , 0
    copie1 dd -1
    copie2 dd -1
    n dd -1
    m dd -1
    minim dd -1
    

segment code use32 class=code
    start:
        
        push dword afisare1
        call [printf]
        add esp , 4 
        
        push dword n
        push dword format
        call [scanf]
        add esp , 4*2
        
        push dword afisare2
        call [printf]
        add esp , 4 
        
        push dword m 
        push dword format
        call [scanf]
        add esp , 4 * 2
        
        mov eax , dword[n]
        mov ebx , dword[m]
        
        cmp eax , 0
        je false
        cmp ebx , 0 
        je false
        cmp eax , 1 
        je false
        cmp ebx , 1
        je false
        
        cmp eax , ebx 
        jbe prima
        
        mov dword[minim] , ebx 
        jmp next
        
        prima:
            mov dword[minim] , eax
        
        next:
        xor ecx , ecx
        mov cl , 2
        parcurgere:
            mov dword[copie1] , eax 
            mov dword[copie2] , ebx 
            xor eax , eax 
            mov eax , dword[copie1]
            div cl 
            cmp ah , 0
            je set_value1
            
            jmp final
            
            set_value1:
                mov eax , dword[copie2]
                div cl 
                cmp ah , 0 
                je false
            
            final:
                inc ecx 
                cmp ecx , dword[minim]
                ja true
                mov eax , dword[copie1]
                mov ebx , dword[copie2]
                jmp parcurgere
        
        true:
            push dword adevarat
            call [printf]
            add esp , 4 
            jmp end_code
        
        
        false:
            push dword fals 
            call [printf] 
            add esp , 4
        
        end_code:
        
        push    dword 0      
        call    [exit]       
