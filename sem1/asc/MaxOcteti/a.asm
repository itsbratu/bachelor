bits 32

global start        

extern exit , printf              
import exit msvcrt.dll
import printf msvcrt.dll
extern maxim    
                         

segment data use32 class=data
    s dd 1234A678h , 12345678h , 1AC3B47Dh , 0FEDC9876h
    len equ ($-s)/4
    d times len db -1
    mesaj_afisare db "Suma octetilor este : " , 0
    format_farasemn db "%u " , 0
    format_semn db "%d " , 0

segment code use32 class=code
    start:
    
        xor ecx , ecx 
        mov esi , s
        mov edi , d
        
        mov ecx , len
        
        push dword ecx
        call maxim
        
        mov esi , d
        mov ecx , len
        xor edx , edx
        
        parcurgere_rezultat:
            xor eax , eax
            lodsb
            
            pushad
            push dword eax
            push dword format_farasemn
            call [printf]
            add esp , 4 * 2 
            popad   
            
            add edx , eax 
        
        loop parcurgere_rezultat
        
        pushad
        push dword mesaj_afisare
        call [printf]
        add esp , 4 
        popad
        
        push dword edx 
        push dword format_semn
        call [printf]
        add esp , 4 * 2
        
        push    dword 0      
        call    [exit]       
