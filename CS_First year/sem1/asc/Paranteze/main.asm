bits 32

global start        

extern exit , printf             
import exit msvcrt.dll    
import printf msvcrt.dll     

segment data use32 class=data
    s db "[](()){}{}{}[" , 0 
    len equ ($-s)
    rotunde dd 0
    patrate dd 0
    acolade dd 0
    true db "Parantezarea data este corecta ! " , 0
    false db "Parantezarea data nu este corecta ! " , 0

segment code use32 class=code
    start:
        
        mov ecx , len 
        dec ecx 
        mov esi , s 
        
        parcurgere: 
            lodsb
            xor ebx , ebx 
            cmp al , '('
            je rotunda1
            cmp al , ')'
            je rotunda2
            cmp al , '['
            je patrata1
            cmp al , ']'
            je patrata2
            cmp al , '{'
            je acolada1
            cmp al , '}'
            je acolada2
            
            rotunda1:
                xor ebx , ebx 
                mov ebx , dword[rotunde]
                inc ebx
                mov dword[rotunde] , ebx 
                jmp final_curr
            rotunda2:
                xor ebx , ebx 
                mov ebx , dword[rotunde]
                dec ebx 
                cmp ebx , 0 
                jl not_solution
                mov dword[rotunde] , ebx
                jmp final_curr
             patrata1:
                xor ebx , ebx 
                mov ebx , dword[patrate]
                inc ebx 
                mov dword[patrate] , ebx
                jmp final_curr
             jmp next_one
             revenire:
                loop parcurgere
                jmp comp_zero
             next_one:
             patrata2:
                xor ebx , ebx 
                mov ebx , dword[patrate]
                dec ebx
                cmp ebx , 0
                jl not_solution
                mov dword[patrate] , ebx
                jmp final_curr
             acolada1:
                xor ebx , ebx 
                mov ebx , dword[acolade]
                inc ebx 
                mov dword[acolade] , ebx 
                jmp final_curr
             acolada2:
                xor ebx , ebx
                mov ebx , dword[acolade]
                dec ebx 
                cmp ebx , 0 
                jl not_solution
                mov dword[acolade] , ebx 
                jmp final_curr
            
        final_curr: 
            cmp ecx , 0 
            ja revenire
        
        comp_zero:
        mov eax , dword[rotunde]
        mov ebx , dword[patrate]
        mov ecx , dword[acolade]
        
        cmp eax , 0 
        jne not_solution
        cmp ebx , 0 
        jne not_solution
        cmp ecx , 0 
        jne not_solution
        
        push dword true
        call [printf]
        add esp , 4 
        jmp final_prog

        
        not_solution:
            push dword false
            call [printf]
            add esp , 4
            
        final_prog:
        
        push    dword 0      
        call    [exit]       
