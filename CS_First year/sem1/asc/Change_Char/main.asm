bits 32

global start        

extern exit , printf , scanf              
import exit msvcrt.dll    
import printf msvcrt.dll    
import scanf msvcrt.dll 

segment data use32 class=data
    sir db "hppopdahhhhhh" , 0
    len equ ($-sir)
    curr dd -1
    maxim dd -1
    litera db 0
    format db "Litera cu frecventa maxima este : %c" , 0
    
segment code use32 class=code
    start:
        mov bl , 'a'
        litere_mici:
        
            xor eax , eax
            mov dword[curr] , eax
        
            cmp bl , 'z'
            ja iesire_mici
            
            mov esi , sir
            xor ecx , ecx
            mov ecx , len
            dec ecx
            parcurgere_sir:
                lodsb
                cmp bl , al
                jne final_parcurgere
                
                xor edx , edx
                mov edx , dword[curr]
                inc edx
                mov dword[curr] , edx
                
                final_parcurgere:
            
            loop parcurgere_sir
            
            xor edx , edx
            mov edx , dword[curr]
            cmp edx , dword[maxim]
            jnge not_changed
            
            xor edx , edx
            mov edx , dword[curr]
            mov dword[maxim] , edx
            mov byte[litera] , bl
            
            not_changed:
            inc bl
            jmp litere_mici
            
        iesire_mici:
        
        xor ebx , ebx
        mov bl , byte[litera]
        
        push dword ebx
        push dword format
        call [printf]
        add esp , 4*2
        
        push    dword 0      
        call    [exit]       
