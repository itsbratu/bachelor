bits 32

global start        

extern exit , printf               
import exit msvcrt.dll
import printf msvcrt.dll    
                         

segment data use32 class=data
     s db 10 , 1 , 9 , 88 , 77 , 88 , 9 , 1 , 10 , 100   
     len equ ($-s)
     copie dd -1
     negative db "Sirul dat nu este palindromic!" , 0 
     affirmative db "Sirul dat este palindromic!" , 0

segment code use32 class=code
    start:
    
        mov ax , len 
        cmp ax , 1
        je is_palindrom
        mov bl , 2 
        div bl ; avem restul in ah si catul in al 
        
        xor ecx , ecx 
        mov cl , al
        sub cl , 1 
        
        mov eax , 0 
        mov edx , len
        sub edx , 1
        mov esi , s 
        
        parcurgere_palindrom:
            mov dword[copie] , ecx
            xor ecx , ecx 
            mov cl ,  byte[esi+eax]
            mov bl  , byte[esi+edx]
            
            cmp bl , cl 
            jne not_palindrom
            
            mov ecx , dword[copie]
            inc eax 
            dec edx
        
        loop parcurgere_palindrom
        
        jmp is_palindrom
        
        
        not_palindrom:
            push dword negative
            call [printf]
            add esp , 4
        jmp final
            
        is_palindrom:
            push dword affirmative
            call [printf]
            add esp , 4
        
        final:
        
        push    dword 0      
        call    [exit]       
