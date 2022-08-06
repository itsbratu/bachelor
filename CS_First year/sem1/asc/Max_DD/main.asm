bits 32

global start        

extern exit , printf           
import exit msvcrt.dll    
import printf msvcrt.dll     

segment data use32 class=data
    sir dd 21880AAAh , 11883344h , 89101022h , 0A70BCCDh , 12885678h
    len_sir equ ($-sir)/4
    maxim db 0
    ap db -1
    mesaj db "Cel mai mare octet inferior al cuvintelor superioare din aceste dublucuvinte este : %x si apare de %d ori" , 0

segment code use32 class=code
    start:
    
        mov ecx , len_sir
        mov esi , sir
        parcurgere:
            lodsd
            shr eax , 16
            xor ebx , ebx
            xor edx , edx
            mov bl , al
            
            cmp bl , byte[maxim]
            je is_equal
            cmp bl , byte[maxim]
            ja is_greater
            jmp final
            
            is_greater:
                xor edx , edx
                mov dl , 1
                mov byte[maxim] , bl
                mov byte[ap] , dl
                jmp final
            
            is_equal:
                xor edx , edx
                mov dl , byte[ap]
                inc dl
                mov byte[ap] , dl
            
            final:
            
        loop parcurgere
        
        xor eax , eax 
        xor ebx , ebx
        mov al , byte[maxim]
        mov bl , byte[ap]
        
        push ebx
        push eax
        push mesaj
        call [printf]
        add esp , 4*3
        
        
        push    dword 0      
        call    [exit]       
