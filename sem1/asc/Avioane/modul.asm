bits 32                         
segment code use32 public code
global liniarizare

liniarizare:
	mov eax , dword[esp+8]   
    mov ecx , dword[esp+4]
    
    mov esi , ecx ; se parcurge sirul 
    xor edx , edx
    mov edx , eax ; se retine indexul citit
    xor ecx , ecx 
    parcurgere_sir:
        lodsb 
        cmp al , -1
        je iesire
        inc ecx
        jmp parcurgere_sir
    
    iesire:
    
    xor eax , eax 
    mov al , 1
    gasire_lungime:
        mov bl , al 
        mul al
        cmp al , cl
        je iesire2
        mov al , bl
        inc al 
        jmp gasire_lungime
    
    iesire2:
    
    xor eax , eax 
    mov al , bl
    
    xor ecx , ecx 
    xor ebx , ebx 
    mov bl , al
    mov ax , dx 
    div bl
    
    xor ebx , ebx 
    xor ecx , ecx 
    mov bl , ah
    mov cl , al
    inc bl 
    inc cl
    
    ret 8