bits 32

global start        

extern exit , printf              
import exit msvcrt.dll    
import printf msvcrt.dll     

segment data use32 class=data
    s dq 12345678h , 0AABBCCDDh , 12345678AABBCCDDh , 2h , 0Dh , 22AA22AA22AAAh
    len equ ($-s)/8
    copie dd -1
    index dd 0
    carry dd -1
    secv_curr dd 0
    secv_max dd -1
    index_max dd 0
    mesaj db "Elementul la index %d are %d astfel de secvente" , 0
    
segment code use32 class=code
    start:
    
        mov esi , s
        mov ecx , len
        repeta:
        
            mov ebx , -1
            mov dword[carry] , ebx
            
            mov ebx , 0
            mov dword[secv_curr] , ebx
       
            mov dword[copie] , ecx
            lodsd 
            mov ecx , 32
            shiftare1:
                xor ebx , ebx
                shr eax , 1
                adc ebx , 0 
                cmp ebx , 0
                je is_zero
                
                mov ebx , 0
                cmp ebx , dword[carry]
                jne not_good
                
                mov ebx , dword[secv_curr]
                inc ebx 
                mov dword[secv_curr] , ebx
                jmp not_good
                
                is_zero:
                    mov ebx , 0
                    mov dword[carry] , ebx
                
                not_good:
                    mov ebx , -1
                    mov dword[carry] , ebx
                
            loop shiftare1
            jmp salt
            revenire1:
                mov ecx , dword[copie]
                loop repeta
                
            jmp final_gasire_element    
            
            salt:
            lodsd
            mov ecx , 32
            shiftare2:
                xor ebx , ebx 
                shr eax , 1
                adc ebx , 0
                cmp ebx , 0 
                je is_zero2
                
                mov ebx , 0
                cmp ebx , dword[carry]
                jne not_good2
                
                mov ebx , dword[secv_curr]
                inc ebx 
                mov dword[secv_curr] , ebx
                jmp not_good2
                
                is_zero2:
                    mov ebx , 0
                    mov dword[carry] , ebx
                 
                not_good2:
                    mov ebx , -1
                    mov dword[carry] , ebx
            loop shiftare2
            
            mov ebx , dword[secv_curr]
            cmp ebx , dword[secv_max]
            jl final_repeta
            
            mov ebx , dword[secv_curr]
            mov dword[secv_max] , ebx
            mov ebx , dword[index]
            mov dword[index_max] , ebx
            
            inc ebx 
            mov dword[index] , ebx
            mov ecx , dword[copie]
        
        final_repeta:
            cmp ecx , 0
            ja revenire1
        
        final_gasire_element:
        
        push dword [secv_max]
        push dword [index_max]
        push dword mesaj
        call [printf]
        add esp , 4*3
        
        push    dword 0      
        call    [exit]       
