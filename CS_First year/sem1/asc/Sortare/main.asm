bits 32

global start        

extern exit               
import exit msvcrt.dll    
                         

segment data use32 class=data
    s db 5 , 10 , 1 , 2
    len_s equ ($-s)
    
segment code use32 class=code
    start:
        
        mov eax , 0
        mov esi , s
        indice1:
            mov ebx , len_s
            dec ebx 
            cmp eax , ebx 
            je final_sortare
            mov ebx , eax 
            inc ebx 
            indice2:
                mov cl , byte[esi+eax]
                mov dl , byte[esi+ebx]
                cmp cl , dl
                jg schimbare
                jmp final_ind2
                
                schimbare:
                    mov byte[esi+eax] , dl
                    mov byte[esi+ebx] , cl
                
                final_ind2:
                    inc ebx
                    cmp ebx , len_s
                    je final_ind1
                jmp indice2
                
        final_ind1:        
            inc eax 
            jmp indice1
        
        final_sortare:
        
        push    dword 0      
        call    [exit]       
