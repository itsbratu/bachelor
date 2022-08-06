bits 32                         
segment code use32 public code
global changechar

changechar:

    xor eax , eax 
    xor ebx , ebx
    xor ecx , ecx

    mov eax , [esp+12] ; in eax vom avea caracterul c
    mov ebx , [esp+8] ; in ebx vom avea operatia curenta
    mov edx , [esp+4] ; in edx vom avea un nr n reprezentat pe un octet
    
    cmp bl , '-'
    je op_minus 
    
    and eax , edx 
    add eax , 'a'
    jmp final
    ; vom avea in eax rezultatul operatiei (c&n) + 'a'
    
    op_minus:
        cmp edx , 0
        je final
    
        mov ecx , edx
        parcurgere_litere:
            cmp al , 'a'
            je jump_to_z
            
            dec al
            jmp final_parcurgere
            
            jump_to_z:
                mov al , 'z'
            final_parcurgere:
        loop parcurgere_litere
        
    final:
        ret 12