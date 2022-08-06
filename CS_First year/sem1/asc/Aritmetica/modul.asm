bits 32                         
segment code use32 public code
global aritmetica

aritmetica:
    mov eax , dword[esp+12]
    mov ebx , dword[esp+8]
    mov ecx , dword[esp+4]
    
    sub eax , ebx 
    sub ebx , ecx 
    cmp eax , ebx 
    jne false_prog
    
    xor eax , eax 
    mov eax , 1
    jmp end_prod
    
    false_prog:
        xor eax , eax 
    end_prod:
    
    ret 12