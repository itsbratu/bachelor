bits 32

global start        

extern exit , printf               
import exit msvcrt.dll
import printf msvcrt.dll    
                         

segment data use32 class=data
    s dd 1234A678h , 12785634h , 1A4D3C28h 
    len equ ($-s)/4
    d times len dw 0FFFFh
    sum dd 0
    copie dd -1
    format dd "%d" , 0
    
segment code use32 class=code
    start:
        mov esi , s
        mov ecx , len
        mov edi , d
        parcurgere:
            xor eax , eax
            lodsd
            mov al , ah 
            stosb
            shr eax , 16
            mov al , ah 
            stosb
        
        loop parcurgere
        
        mov esi , d
        mov ecx , len
        
        parcurgere2:
            xor eax , eax
            lodsw
            
            mov dword[copie] , ecx
            xor ecx , ecx
            mov ecx , 16
                shiftare:
                    clc 
                    xor ebx , ebx
                    shr ax , 1 
                    adc ebx , 0
                    cmp ebx , 1
                    jne not_one
                    
                    xor edx , edx
                    mov edx ,dword[sum]
                    inc edx 
                    mov dword[sum] , edx
                    
                    not_one:
                
                loop shiftare
            mov ecx , dword[copie]
        
        loop parcurgere2
        
        mov eax , dword[sum]
        
        push eax
        push dword format
        call [printf]
        add esp , 4*2
        
        push    dword 0      
        call    [exit]       
