bits 32

global start        

extern exit, printf               
import exit msvcrt.dll    
import printf msvcrt.dll      

segment data use32 class=data
    s dq 12348aaccc123340h , 0acb1212abab2323h , 91aab121ccaa1212h , 4512abab12341234h , 1111222233334444h , 8000800070006000h , 1212121212121212h
    len equ ($-s)/8
    prime times len db -1
    copie dd -1
    format db "%d " , 0 
    

segment code use32 class=code
    start:
    
        mov esi , s 
        mov edi , prime
        mov ecx , len 
        
        parcurgere:
            xor edx , edx
            lodsd
            mov dword[copie] , ecx
            mov ecx , 32
            shiftare1:
                xor ebx , ebx 
                shr eax , 1
                adc ebx , 0
                
                cmp ebx , 1 
                jne not_add
                
                add edx , 1
                not_add:
            loop shiftare1
            
            lodsd
            mov ecx , 32
            shiftare2:
                xor ebx , ebx
                shr eax , 1
                adc ebx , 0
                
                cmp ebx , 1
                jne not_add2
                
                add edx , 1
                not_add2:
            loop shiftare2
            
            mov al , dl
            stosb
            mov ecx , dword[copie]
        
        loop parcurgere
        
        mov ecx , len
        mov esi , prime
        afisare:
            xor eax , eax 
            lodsb
            mov bl , al
            mov dl , 2
            
            cmp al , 2
            je is_prime
            cmp al , 2 
            jl not_prime
            
                impartire:
                    div dl
                    cmp ah , 0
                    je not_prime
                    
                    inc dl
                    xor eax , eax 
                    mov al , bl
                    cmp dl , al
                    je is_prime
                    jmp impartire
            is_prime:
               xor eax , eax 
               mov al , bl
               
               push eax
               push dword format
               call [printf]
               add esp , 4 * 2
            not_prime:
            
        loop afisare
        
        
        push    dword 0      
        call    [exit]       
