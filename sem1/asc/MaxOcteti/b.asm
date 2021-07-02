bits 32
segment code use32 public code   
global maxim

maxim:

    mov ecx , [esp+4]
    xor eax , eax
    xor ebx , ebx 
    xor edx , edx 
    
    parcurgere:
        xor edx , edx
        xor eax , eax
        lodsd
        mov dl , al
        cmp ah , dl
        jna not_greater1
        
        mov dl , ah
        
        not_greater1:
            shr eax , 16
            cmp al , dl
            jna not_greater2
            
            mov dl , al
            
            not_greater2:
            cmp ah , dl
            jna not_greater3
            
            mov dl , ah
            not_greater3:
            xor eax , eax 
            mov al , dl
            stosb
    loop parcurgere
    
    ret 4
            