bits 32

global start        

extern exit , printf , scanf           
import exit msvcrt.dll    
import printf msvcrt.dll
import scanf msvcrt.dll
                         

segment data use32 class=data
    n dd -1
    nr_citit dd -1
    s times 10 dd -1
    d times 10 dd -1
    mesaj_citire db "Introduceti numarul n : " , 0
    mesaj_numar db "Introduceti urmatorul numar din sir : " , 0
    format db "%d" , 0
    contor dd -1
    
segment code use32 class=code
    start:
        
        push dword mesaj_citire
        call [printf]
        add esp , 4 
        
        push dword n
        push dword format
        call [scanf]
        add esp , 4 * 2
        
        xor ecx , ecx 
        mov ecx , dword[n]
        mov edi , s
        citire:
            pushad
            push dword mesaj_numar
            call [printf]
            add esp , 4
            popad
            
            pushad
            push dword nr_citit
            push dword format
            call [scanf]
            add esp , 4 * 2
            popad
            
            xor eax , eax
            mov eax , dword[nr_citit]
            stosd
        
        loop citire
        
        mov ecx , dword[n]
        mov esi , s
        mov edi , d
        parcurgere:
            mov dword[contor] , ecx 
            xor ecx , ecx
            xor eax , eax 
            xor ebx , ebx 
            xor edx , edx 
            
            lodsd
            mov bx , 10
            
            cifre:
                xor edx , edx
                cmp ax , 0
                je final_cifre
                
                div bx 
                test dx , 1 
                jnz not_par
                
                add ecx , edx
                
                not_par:
                jmp cifre
            
            final_cifre:
            xor eax , eax 
            mov eax , ecx 
            stosd
            mov ecx , dword[contor]
        
        loop parcurgere
        
        push    dword 0      
        call    [exit]       
