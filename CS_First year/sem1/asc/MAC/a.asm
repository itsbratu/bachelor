bits 32

global start        

extern exit , printf              
import exit msvcrt.dll    
import printf msvcrt.dll
                         

segment data use32 class=data
    n db "2a6" , 0
    lng dd 3
    rezultat dd 0
    copie dd -1
    mesaj db "Numarul convertit este : %d " , 0

segment code use32 class=code
    start:
        
        mov esi , n 
        mov ecx , dword[lng]

        repeta:
            xor eax , eax
            lodsb
            cmp al , '9'
            ja is_letter
            
            sub al , '0'
            jmp conversie
            is_letter:
                cmp al , 'a'
                je a_letter
                
                cmp al , 'b'
                je b_letter
                
                cmp al , 'c'
                je c_letter
                
                cmp al , 'd'
                je d_letter
                
                cmp al , 'e'
                je e_letter
                
                cmp al , 'f'
                je f_letter
            
             a_letter:
                mov al , 10
                jmp conversie
             b_letter:
                mov al , 11
                jmp conversie
             c_letter:
                mov al , 12
                jmp conversie
             d_letter:
                mov al , 13
                jmp conversie
             e_letter:
                mov al , 14
                jmp conversie
             f_letter:
                mov al , 15
             conversie:
                mov dword[copie] , ecx
                dec ecx
                cmp ecx , 0
                je ultima_poz
                shiftare:
                    shl eax , 4
                loop shiftare
                ultima_poz:
                xor ebx , ebx
                mov ebx , dword[rezultat]
                add ebx , eax
                mov dword[rezultat] , ebx
                mov ecx , dword[copie]
        
        loop repeta
        
        push dword [rezultat]
        push dword mesaj
        call [printf]
        add esp , 4*2
        
        push    dword 0      
        call    [exit]       
