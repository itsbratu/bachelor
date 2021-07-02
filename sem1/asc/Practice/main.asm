bits 32

global start        

extern exit , printf              
import exit msvcrt.dll
import printf msvcrt.dll   
                         

segment data use32 class=data
    format db "%d" , 0
    copie dd -1
    
segment code use32 class=code
    start:
        
        mov eax , 4 
        
        push dword eax
        push dword format
        call [printf]

        
        push    dword 0      
        call    [exit]       
