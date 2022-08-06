bits 32

global start        

extern exit , printf , scanf             
import exit msvcrt.dll
import printf msvcrt.dll
import scanf msvcrt.dll   
extern aritmetica

segment data use32 class=data
    n dd -1 
    m dd -1 
    p dd -1 
    true db "Cele trei numere se afla in progresie aritmetica!" , 0
    false db "Cele trei numere nu se afla in progresie geometrica!" , 0
    first_number db "Introduceti primul numar : " , 0 
    second_number db "Introduceti al doilea numar : " , 0
    thrid_number db "Introduceti al treilea numar : " , 0 
    format db "%d" , 0
    
segment code use32 class=code
    start:
    
        push dword first_number
        call [printf]
        add esp , 4 
        
        push dword n
        push dword format
        call [scanf]
        add esp , 4 * 2
        
        push dword second_number
        call [printf]
        add esp , 4 
        
        push dword m 
        push dword format
        call [scanf]
        add esp , 4 * 2 
        
        push dword thrid_number
        call [printf]
        add esp , 4 
        
        push dword p
        push dword format
        call [scanf]
        add esp , 4 * 2 
        
        xor eax , eax 
        xor ebx , ebx 
        xor ecx , ecx 
        
        push dword[n]
        push dword[m]
        push dword[p]
        call aritmetica
        
        cmp eax , 0
        je not_prog
        
        push dword true
        call [printf]
        add esp , 4 
        jmp final
        
        not_prog:
            push dword false
            call [printf]
            add esp , 4 
        final:   
        
        push    dword 0      
        call    [exit]       
