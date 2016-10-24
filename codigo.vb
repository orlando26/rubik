'Lo que se coloca en public se podrá utilizar en varios subs o en varias funciones.

Public ColocarColor As Range                         'Sólo para excel
Public ColorBoton As Variant
Public ws As Worksheet
Public wsA As Worksheet
Public wb As Workbook

Public a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z As Variant      'Letras de aristas
Public vA, vB, vC, vD, vE, vF, vG, vH, vI, vJ, vK, vL, vM, vN, vO, vP, vQ, vR, vS, vT, vU, vV, vW, vX As Variant 'Letras de esquinas
Public EsquinasMemo
Public AristasMemo

Private Sub BotonLimpiar_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    
    ColorInicial = RGB(255, 255, 255)                             'Blanco
    ws.Range("M:O").ClearContents
    ws.Range("R2").Value = ""
    
    Range("A4:L12").Interior.Color = ColorInicial                 'Limpia: pone color blanco
    Range("H5").Interior.Color = RGB(255, 255, 255)               'Colores de los centros
    Range("B8").Interior.Color = RGB(0, 112, 192)
    Range("E8").Interior.Color = RGB(255, 152, 1)
    Range("H8").Interior.Color = RGB(0, 176, 80)
    Range("H11").Interior.Color = RGB(255, 255, 0)
    Range("k8").Interior.Color = RGB(255, 0, 0)
    
End Sub

Private Sub BotonBlanco_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(255, 255, 255)
    ColocarColor.Value = "Blanco"
    ws.Range("G2:I2").Interior.Color = ColorBoton

End Sub

Private Sub BotonAzul_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(0, 112, 192)
    ColocarColor.Value = "Azul"
    Range("G2:I2").Interior.Color = ColorBoton

End Sub

Private Sub BotonNaranja_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(255, 152, 1)
    ColocarColor.Value = "Naranja"
    Range("G2:I2").Interior.Color = ColorBoton
    
End Sub

Private Sub BotonVerde_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(0, 176, 80)
    ColocarColor.Value = "Verde"
    Range("G2:I2").Interior.Color = ColorBoton
    
End Sub

Private Sub BotonRojo_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(255, 0, 0)
    ColocarColor.Value = "Rojo"
    Range("G2:I2").Interior.Color = ColorBoton
    
End Sub

Private Sub BotonAmarillo_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    
    ColorBoton = RGB(255, 255, 0)
    ColocarColor.Value = "Amarillo"
    Range("G2:I2").Interior.Color = ColorBoton
    
End Sub

Function Posibles(ByRef variable As Variant)
'----------------------------------------------------------------
'                Posibles (relacionado color - letras)
'----------------------------------------------------------------
  If AristasMemo = 1 Then
    Select Case variable
            Case "bla": Posibles = Array(a, b, c, d)
            Case "azu": Posibles = Array(e, f, g, h)
            Case "nar": Posibles = Array(i, j, k, l)
            Case "ver": Posibles = Array(m, n, o, p)
            Case "roj": Posibles = Array(q, r, s, t)
            Case "ama": Posibles = Array(u, v, w, x)
    End Select
  Else
    Select Case variable
            Case "bla": Posibles = Array(vA, vB, vC, vD)
            Case "azu": Posibles = Array(vE, vF, vG, vH)
            Case "nar": Posibles = Array(vI, vJ, vK, vL)
            Case "ver": Posibles = Array(vM, vN, vO, vP)
            Case "roj": Posibles = Array(vQ, vR, vS, vT)
            Case "ama": Posibles = Array(vU, vV, vW, vX)
    End Select
  End If

    
End Function

Function centro(ByRef variable As Variant)        'Centro
'----------------------------------------------------------------
'                (relacionado letras - color)
'----------------------------------------------------------------
    If AristasMemo = 1 Then

        If (variable = a Or variable = b Or variable = c Or variable = d) Then
            centro = "bla"
        ElseIf (variable = e Or variable = f Or variable = g Or variable = h) Then
            centro = "azu"
        ElseIf (variable = i Or variable = j Or variable = k Or variable = l) Then
            centro = "nar"
        ElseIf (variable = m Or variable = n Or variable = o Or variable = p) Then
            centro = "ver"
        ElseIf (variable = q Or variable = r Or variable = s Or variable = t) Then
            centro = "roj"
        ElseIf (variable = u Or variable = v Or variable = w Or variable = x) Then
            centro = "ama"
        End If
    
    ElseIf EsquinasMemo = 1 Then

        If (variable = vA Or variable = vB Or variable = vC Or variable = vD) Then
            centro = "bla"
        ElseIf (variable = vE Or variable = vF Or variable = vG Or variable = vH) Then
            centro = "azu"
        ElseIf (variable = vI Or variable = vJ Or variable = vK Or variable = vL) Then
            centro = "nar"
        ElseIf (variable = vM Or variable = vN Or variable = vO Or variable = vP) Then
            centro = "ver"
        ElseIf (variable = vQ Or variable = vR Or variable = vS Or variable = vT) Then
            centro = "roj"
        ElseIf (variable = vU Or variable = vV Or variable = vW Or variable = vX) Then
            centro = "ama"
        End If
    
    End If
    
End Function

Function Hacia(ByRef variable As Variant)
'----------------------------------------------------------------
'              Color de buffer, pieza o pareja
'----------------------------------------------------------------
    If Range(variable).Interior.Color = RGB(255, 255, 255) Then
        Hacia = "bla"
    ElseIf Range(variable).Interior.Color = RGB(255, 255, 0) Then
        Hacia = "ama"
    ElseIf Range(variable).Interior.Color = RGB(0, 112, 192) Then
        Hacia = "azu"
    ElseIf Range(variable).Interior.Color = RGB(0, 176, 80) Then
        Hacia = "ver"
    ElseIf Range(variable).Interior.Color = RGB(255, 0, 0) Then
        Hacia = "roj"
    ElseIf Range(variable).Interior.Color = RGB(255, 152, 1) Then
        Hacia = "nar"
    End If

End Function

Function Perteneciente(ByRef variable As Variant)
'----------------------------------------------------------------
'                Pertenecientes (parejas)
'----------------------------------------------------------------
    
    If AristasMemo = 1 Then
        Select Case variable
            Case a: Perteneciente = m
            Case b: Perteneciente = i
            Case c: Perteneciente = e
            Case d: Perteneciente = q
            Case e: Perteneciente = c
            Case f: Perteneciente = l
            Case g: Perteneciente = w
            Case h: Perteneciente = r
            Case i: Perteneciente = b
            Case j: Perteneciente = p
            Case k: Perteneciente = x
            Case l: Perteneciente = f
            Case m: Perteneciente = a
            Case n: Perteneciente = t
            Case o: Perteneciente = u
            Case p: Perteneciente = j
            Case q: Perteneciente = d
            Case r: Perteneciente = h
            Case s: Perteneciente = v
            Case t: Perteneciente = n
            Case u: Perteneciente = o
            Case v: Perteneciente = s
            Case w: Perteneciente = g
            Case x: Perteneciente = k
        End Select
        
   ElseIf EsquinasMemo = 1 Then
        Select Case variable
            Case vA: Perteneciente = Array(vN, vQ)
            Case vB: Perteneciente = Array(vJ, vM)
            Case vC: Perteneciente = Array(vF, vI)
            Case vD: Perteneciente = Array(vR, vE)
            Case vE: Perteneciente = Array(vR, vD)
            Case vF: Perteneciente = Array(vC, vI)
            Case vG: Perteneciente = Array(vL, vX)
            Case vH: Perteneciente = Array(vW, vS)
            Case vI: Perteneciente = Array(vF, vC)
            Case vJ: Perteneciente = Array(vB, vM)
            Case vK: Perteneciente = Array(vP, vU)
            Case vL: Perteneciente = Array(vX, vG)
            Case vM: Perteneciente = Array(vJ, vB)
            Case vN: Perteneciente = Array(vA, vQ)
            Case vO: Perteneciente = Array(vT, vV)
            Case vP: Perteneciente = Array(vU, vK)
            Case vQ: Perteneciente = Array(vN, vA)
            Case vR: Perteneciente = Array(vD, vE)
            Case vS: Perteneciente = Array(vH, vW)
            Case vT: Perteneciente = Array(vV, vO)
            Case vU: Perteneciente = Array(vK, vP)
            Case vV: Perteneciente = Array(vO, vT)
            Case vW: Perteneciente = Array(vS, vH)
            Case vX: Perteneciente = Array(vG, vL)
        End Select
        
    End If
    
End Function

Private Sub Resolver_Click()

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    
    Range("G4:I6").Interior.Color = RGB(255, 255, 255)               'Colores de los centros
    Range("A7:C9").Interior.Color = RGB(0, 112, 192)
    Range("D7:F9").Interior.Color = RGB(255, 152, 1)
    Range("G7:I9").Interior.Color = RGB(0, 176, 80)
    Range("J7:L9").Interior.Color = RGB(255, 0, 0)
    Range("G10:I12").Interior.Color = RGB(255, 255, 0)
    
End Sub

Private Sub Solucion_Click()

EsquinasMemo = 1
AristasMemo = 0

'-------------------------------------------------------------------------------------------------------------
'                      Declaración de variables y otras inicializaciones

Dim PIEZA                   As Variant              'Guardará la pieza que se está analizando: a, b, c, d...
                                                      'es Variant porque también se puede referir a su ubicación, ej a="h6"
Dim Pareja1                 As Variant             'Pareja(perteneciente) de PIEZA
Dim Pareja2                 As Variant

Dim buf1, buf2, buf3        As Variant              'Son los colores del buffer y del perteneciente(pareja) de éste, ej buf = "azu" para azul
Dim HaciaColor, HaciaColor2, HaciaColor3 As Variant 'Colores de la pieza analizada y el perteneciente(pareja) de ésta. ej. HaciaColor="bla"...
Dim Revisados               As New Collection       'Lista de PIEZAs que ya se revisaron
Dim Esquinas                 As New Collection       'Lista de PIEZAs (Esquinas) "memorizadas"
Dim Completo                As New Collection       'Lista de "a" a "x", se le resta "Revisados" y quedan las Esquinas que aún no se revisan.
Dim Posible                                         'Arreglo de letras relacionadas a una cara. Ej a,b,c,d para blanco, i,j,k,l para Naranja, etc.
Dim cc                      As Integer              'Contador que servirá para revisar cada pieza en el arreglo "Posible"
Dim zz                      As Integer              'Servirá para eliminar de "Completos" las esquinas que hay en "revisados"; también para escribir en la hoja las Esquinas memorizadas.
Dim ParejaTemp              As Variant              'Pareja de la pieza hacia donde "podría" ir la pieza que está en el buffer
Dim HaciaColor2Temp         As Variant              'Color de ParejaTemp
Dim Cuantos                 As Integer              'Cantidad de letras en la lista Revisados
Dim RandomNo                As Integer              'Numero random que se usará al iniciar otro ciclo
Dim buffer                  As Variant              'Pieza buffer de ciclos que no empiezan en a o m
Dim ParejaB                 As Variant              'Pareja de buffer de ciclos que no empiezan en a o m
Dim AristaNombre            As Range                'Se usará como la dirección donde se colocarán las Esquinas memorizadas.
Dim ConteoEsquinas           As Integer              'Se usará para saber cuántas Esquinas se memorizaron

Dim CountA As Integer                               'Contador para revisar si la arista es par o impar
Dim CountAesPar As Integer                          'Se usará para saber si la posición de la arista en el arreglo memorizado es par o impar
Dim Paridad As String                               'Se usará para saber si existe paridad o no
Set wsA = Worksheets("Algs Modificados")            'wsA es la hoja que contiene tooodos los algoritmos


Set ws = Worksheets("Simulación_Aristas")
ws.Range("M:O").ClearContents                       'Borra los resultados anteriores escritos en la hoja
ws.Range("R2").Value = ""                           'Borra los resultados anteriores escritos en la hoja


'-------------------------------------------------------------------------------------------------------------
'                      Referencias de letras a la hoja "Simulación_aristas"

vA = "i6"
vB = "g6"
vC = "g4"
vD = "i4"
vE = "a7"
vF = "c7"
vG = "c9"
vH = "a9"
vI = "d7"
vJ = "f7"
vK = "f9"
vL = "d9"
vM = "g7"
vN = "i7"
vO = "i9"
vP = "g9"
vQ = "j7"
vR = "l7"
vS = "l9"
vT = "j9"
vU = "g10"
vV = "i10"
vW = "i12"
vX = "g12"

'------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE SOLUCIÓN (MEMORIZACIÓN)
'------------------------------------------------------------------------------------------------------------------------------------------

'Blanco arriba, verde en frente
    
PIEZA = vA                     'Siempre se comienza a memorizar el primer ciclo en el buffer (en la pieza A)
buf1 = "bla"                  'El color del buffer siempre será blanco
buf2 = "ver"                  'El color de la pareja1 del buffer siempre será verde
buf3 = "roj"                  'El color de la parej2 del buffer siempre será rojo

loop1 = 0
nunca = 0

Do 'Loop1 para paso comienza ciclo

    Do 'loop2
    
        Do While nunca = 0          'loop 1.1
            
            If loop1 = 1 Then
               Exit Do                  'sale de loop1.1
            End If
            
            '-------------------------------------------------------------------------------------------------
            '                                      1. COLORES EN EL BUFFER
                  
             HaciaColor = Hacia(PIEZA)        'Función "Hacia" regresa el color actual de PIEZA
        
            '-------------------------------------------------------------------------------------------------
            '                                        Perteneciente (Pareja)
        
             Pareja1 = Perteneciente(PIEZA)(0)    'Perteneciente de PIEZA devuelve letra pareja1 de PIEZA
             Pareja2 = Perteneciente(PIEZA)(1)
        
            '-------------------------------------------------------------------------------------------------
            '                                        Color de pareja
        
             HaciaColor2 = Hacia(Pareja1)      'Función "Hacia" regresa el color actual de Pareja
             HaciaColor3 = Hacia(Pareja2)
        
        
            '-------------------------------------------------------------------------------------------------
            '                                      2. PIEZAS REVISADAS
            
             Revisados.Add PIEZA              'Se agregar PIEZA y Pareja a la lista de "Revisados"
             Revisados.Add Pareja1
             Revisados.Add Pareja2
        
            If (HaciaColor = buf1 And HaciaColor2 = buf2 And HaciaColor3 = buf3) _
                Or (HaciaColor = buf1 And HaciaColor2 = buf3 And HaciaColor3 = buf2) _
                Or (HaciaColor = buf2 And HaciaColor2 = buf1 And HaciaColor3 = buf3) _
                Or (HaciaColor = buf2 And HaciaColor2 = buf3 And HaciaColor3 = buf1) _
                Or (HaciaColor = buf3 And HaciaColor2 = buf1 And HaciaColor3 = buf2) _
                Or (HaciaColor = buf3 And HaciaColor2 = buf2 And HaciaColor3 = buf1) Then 'Si los colores en el buffer SON los colores del buffer
            
                rompe = 1
                Exit Do 'salir del loop 1.1
                
            End If
        
        
            '-------------------------------------------------------------------------------------------------
            '                                      3. COMIENZA CICLO DE "MEMORIZACIÓN"
            nunca = 1
        Loop 'loop1.1
    
        If rompe = 1 Then
            rompe = 0
            Exit Do 'salir de loop2
        End If
                                                                 'Comienza ciclo para memorizar aristas
        Posible = Posibles(HaciaColor)                          'La función "Posibles" devuelve las piezas donde podría
                                                                ' ir la pieza que está en el buffer, depende del color de PIEZA
        
        loop3 = 0
        Do While loop3 = 0 'loop3
    
            ParejaTemp1 = Perteneciente(Posible(cc))(0)             'Pareja temporal es la pareja de la 1era, 2da, 3era o 4ta pieza del arreglo "Posibles()"
            ParejaTemp2 = Perteneciente(Posible(cc))(1)
            HaciaColorTemp2 = centro(ParejaTemp1)      'Color de la pareja temporal a donde podría ir la pieza que está en el buffer
            HaciaColorTemp3 = centro(ParejaTemp2)
            
            If ((HaciaColorTemp2 = HaciaColor2 And HaciaColorTemp3 = HaciaColor3) = 0 And _
               (HaciaColorTemp2 = HaciaColor3 And HaciaColorTemp3 = HaciaColor2) = 0) Then            'Si el color de la pareja de PIEZA no es igual al color de la pareja de Posible
                cc = cc + 1                                        'Incrementa el contador en 1 para checar la siguiente pieza en "Posibles()"
                loop3 = 0       'Para repetir el Do while
            Else
                loop3 = 1       'Para salir del do
            End If
        Loop 'loop3                                                 'Regresa a para revisar la siguiente pieza posible
    
        Esquinas.Add Posible(cc)
        
        PIEZA = Posible(cc)                                     'Ahora se revisará a dónde va esta nueva pieza
        cc = 0
        nunca = 0
        loop1 = 0
    
    Loop 'loop2
                                                            'Se llega aquí cuando el ciclo se completa (las piezas regresan al buffer)
    Set Completo = Nothing                                  'Vacía la lista de letras de aristas sin revisar
    Completo.Add vA, vA                                       'Agrega arista "a" (dirección: H6) a la lista de aristas sin revisar, y su nombre = a
    Completo.Add vB, vB
    Completo.Add vC, vC                                       'La primer letra lleva a la dirección, aquí c=celda h4
    Completo.Add vD, vD                                       'La segunda letra es el nombre de esa dirección, aquí es d.
    Completo.Add vE, vE
    Completo.Add vF, vF
    Completo.Add vG, vG
    Completo.Add vH, vH
    Completo.Add vI, vI
    Completo.Add vJ, vJ
    Completo.Add vK, vK
    Completo.Add vL, vL
    Completo.Add vM, vM
    Completo.Add vN, vN
    Completo.Add vO, vO
    Completo.Add vP, vP
    Completo.Add vQ, vQ
    Completo.Add vR, vR
    Completo.Add vS, vS
    Completo.Add vT, vT
    Completo.Add vU, vU
    Completo.Add vV, vV
    Completo.Add vW, vW
    Completo.Add vX, vX

    Cuantos = Revisados.Count                                       'Cuantos es la cantidad de aristas revisadas
    
    For zz = 1 To Cuantos
        On Error Resume Next                                        'Si ocurre error en siguiente linea (si ya se había eliminado la arista)...
                                                                    '...checa la siguiente letra en Revisados
        Completo.Remove Revisados(zz)                               'Elimina de la lista Completo las aristas que ya se revisaron,
                                                                    'Se usará para saber cuantas y cuáles piezas faltan de revisar.
    Next zz

    If Completo.Count = 0 Then                                      'Si ya no hay piezas por revisar
'Acaba la memorización
    Exit Do 'sale de loop1
    End If

    '-------------------------------------------------------------------------------------------------
    '                                      4. COMIENZA SIGUIENTE CICLO DE MEMORIZACIÓN

    Randomize                                                       'Inicializa el generador de números aleatorios de la función Rnd
    RandomNo = Int(Completo.Count * Rnd) + 1                        'Número random de 1 hasta el tamaño de Completo (aristas que faltan de revisar)
    
    'Cuando se comienza un ciclo nuevo, se selecciona un buffer nuevo, este buffer nuevo sí se tiene que "memorizar", a diferencia de a o m
    
    PIEZA = Completo(RandomNo)                                      'Pieza será la pieza número "RandomNo" en el arreglo "Completo" (de las que faltaban de revisar)
    buffer = PIEZA                                                  'El buffer es esa pieza random seleccionada.
    buf1 = Hacia(buffer)                                            'Color del nuevo buffer
    HaciaColor = buf1                                               'El color del nuevo buffer indica hacia dónde irá esa pieza(nuevo buffer).

    ParejaB1 = Perteneciente(buffer)(0)                             'Pareja del nuevo buffer..
    ParejaB2 = Perteneciente(buffer)(1)
    Pareja1 = ParejaB1                                              '.. será la pareja de la pieza a analizar (buffer nuevo)
    Pareja2 = ParejaB2
    buf2 = Hacia(ParejaB1)                                          'Color de la pareja del nuevo buffer...
    buf3 = Hacia(ParejaB2)
    HaciaColor2 = buf2                                              '...será el color de la pieza a analizar(buffer nuevo)
    HaciaColor3 = buf3
    
    Esquinas.Add PIEZA                                               'Se agrega el nuevo buffer a aristas memorizadas
    Revisados.Add PIEZA                                             'Se agrega el nuevo buffer y su pareja a piezas revisadas.
    Revisados.Add Pareja1
    Revisados.Add Pareja2
                                                                    'Comienza ciclo (uno nuevo :D, dentro del paso 3)
loop1 = 1
nunca = 1
Loop 'loop1
    

    '-------------------------------------------------------------------------------------------------
    '                 5. TERMINA MEMORIZACIÓN Y ESCRIBE EN LA HOJA LAS ARISTAS MEMORIZADAS


    ConteoEsquinas = Esquinas.Count                                   'Número de aristas memorizadas, contando las repetidas :s
    ConteoEsquinasT = ConteoEsquinas                                  'Número de aristas memorizadas, luego se reducirá si hay repetidas, y servirá
                                                                    'para saber si hay paridad o no
    
    zzT = 1                                                         'Servirá para decrementar la posición donde se colocará la arista memorizada
                                                                    'Si es que se repetían valores
    
    For zz = 1 To ConteoEsquinas
            Set EsquinaNombre = ws.Range("N" & zzT)                       'Escribe arista por arista hacia abajo en la columna N
            EsquinaTemp2 = ws.Range(Esquinas(zz)).Value                    'Guarda letra de arista actual
            
            If EsquinaTemp2 = EsquinaTemp1 Then                           'Si es igual a la anterior, zzT=zzT-1
                zzT = zzT - 2                                            'De todas formas incrementará en 1 cuando zzT=zzT+1
                ConteoEsquinasT = ConteoEsquinasT - 2                      'Hay una arista repetida, entonces se eliminan las repeticiones (2)
            Else
                EsquinaNombre.Value = ws.Range(Esquinas(zz)).Value         'Si solo se ponia Aristas(zT), escribiría la celda y no la letra
                EsquinaTemp1 = ws.Range(Esquinas(zz)).Value                'Guarda letra de arista actual, será la anterior cuando vuelva a entrar el For
            End If
            
        zzT = zzT + 1                                                    'Incrementa el lugar donde se colocará la siguiente arista memorizada
        
    Next zz
    
    If EsquinaTemp2 = EsquinaTemp1 Then
        Set EsquinaNombre = ws.Range("N" & zzT)
        EsquinaNombre.Value = ""
    End If
    
'--------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE EJECUCIÓN
'-------------------------------------------------------------------------------------------------------------------------------------------

   ' ws.Range("M1").Value = ConteoEsquinasT                'Escribe en M1 la cantidad de aristas "memorizadas"
    
    If (1 - (ConteoEsquinasT Mod 2)) = 0 Then             'Si ConteoAristasT es Impar o par (0 para impar, 1 para par)
        Paridad = "ConParidad"                              'En el método,  es impar el consiteo, existe "paridad"
        Else
        Paridad = "SinParidad"                              'En el método, si el conteo es par, no hay paridad
    End If


For CountE = 1 To ConteoEsquinasT                       'ggg

    '1 si es par, 0 si es impar
    CountEesPar = 1 - (CountE Mod 2)                                'Posición de arista actual es par o impar?

    If ws.Range("N" & CountE).Value = "B" Then                      ' Algoritmos de Arista b
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vBimpar")     '"Abimpar" es el nombre de la celda en hoja wsA="Algs Modificados"
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vBpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "C" Then                 'Arista c
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vCimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vCpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "D" Then                 'Arista d
            ws.Range("O" & CountE).Value = ""
        
     ElseIf ws.Range("N" & CountE).Value = "E" Then                 'Arista e
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vEimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vEpar")
        End If
            
     ElseIf ws.Range("N" & CountE).Value = "F" Then                 'Arista f
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vFimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vFpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "G" Then                 'Arista g
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vGimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vGpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "H" Then                 'Arista h
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vHimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vHpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "I" Then                 'Arista i
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vIimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vIpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "J" Then                 'Arista j
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vJimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vJpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "K" Then                 'Arista k
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vKimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vKpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "L" Then                 'Arista l
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vLimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vLpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "M" Then                 'Arista m
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vMimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vMpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "N" Then                 'Arista n
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vNimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vNpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "O" Then                 'Arista o
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vOimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vOpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "P" Then                 'Arista p
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vPimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vPpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "Q" Then                 'Arista q
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vQimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vQpar")
        End If
    
     ElseIf ws.Range("N" & CountE).Value = "R" Then                 'Arista r
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vRimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vRpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "S" Then                 'Arista s
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vSimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vSpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "T" Then                 'Arista t
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vTimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vTpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "U" Then                 'Arista u
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vUimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vUpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "V" Then                 'Arista v
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vVimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vVpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "W" Then                 'Arista w
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vWimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vWpar")
        End If
        
     ElseIf ws.Range("N" & CountE).Value = "X" Then                 'Arista x
        If CountEesPar = 0 Then
            ws.Range("O" & CountE).Value = wsA.Range("vXimpar")
        Else
            ws.Range("O" & CountE).Value = wsA.Range("vXpar")
        End If
     End If
    
Next CountE
    
    ws.Range("R2").Formula = "=CONCAT(O:O)"                   'Escribe el algoritmo entero para resolver el cubo en celda R2
    ws.Range("R2").Copy
    ws.Range("R2").PasteSpecial xlPasteValues                 'Lo pega ahí mismo para que aparezca como valores y no como fórmula.
    ws.Range("A1").Select
    
'--------------------------------------------------------------------------------------------------------------------------------------------------
'                                       Declaración de variables y otras inicializaciones para ARISTAS
'-------------------------------------------------------------------------------------------------------------------------------------------------

                                                    'es Variant porque también se puede referir a su ubicación, ej a="h6"
Dim Pareja                  As Variant              'Pareja(perteneciente) de PIEZA
Dim Aristas                 As New Collection       'Lista de PIEZAs (aristas) "memorizadas"
Set wsA = Worksheets("Algs Modificados")            'wsA es la hoja que contiene tooodos los algoritmos
Set ws = Worksheets("Simulación_Aristas")

EsquinasMemo = 0
AristasMemo = 1

'-------------------------------------------------------------------------------------------------------------
'                      Referencias de letras a la hoja "Simulación_aristas"
a = "h6"
b = "g5"
c = "h4"
d = "i5"
e = "b7"
f = "c8"
g = "b9"
h = "a8"
i = "e7"
j = "f8"
k = "e9"
l = "d8"
m = "h7"
n = "i8"
o = "h9"
p = "g8"
q = "k7"
r = "l8"
s = "k9"
t = "j8"
u = "h10"
v = "i11"
w = "h12"
x = "g11"

'------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE SOLUCIÓN (MEMORIZACIÓN)
'------------------------------------------------------------------------------------------------------------------------------------------

'Blanco arriba, verde en frente
    
PIEZA = a                     'Siempre se comienza a memorizar el primer ciclo en el buffer (en la pieza a)
buf1 = "bla"                  'El color del buffer siempre será blanco
buf2 = "ver"                  'El color de la pareja del buffer siempre será verde
Set Revisados = Nothing

PasoColorDeBufferA:
    '-------------------------------------------------------------------------------------------------
    '                                      1. COLORES EN EL BUFFER
          
     HaciaColor = Hacia(PIEZA)        'Función "Hacia" regresa el color actual de PIEZA

    '-------------------------------------------------------------------------------------------------
    '                                        Perteneciente (Pareja)

     Pareja = Perteneciente(PIEZA)    'Perteneciente de PIEZA devuelve letra pareja de PIEZA.
                                      'Ej: para "a" es "m", para "i" es "b" etc.

    '-------------------------------------------------------------------------------------------------
    '                                        Color de pareja

     HaciaColor2 = Hacia(Pareja)      'Función "Hacia" regresa el color actual de Pareja

    '-------------------------------------------------------------------------------------------------
    '                                      2. PIEZAS REVISADAS
    
     Revisados.Add PIEZA              'Se agregar PIEZA y Pareja a la lista de "Revisados"
     Revisados.Add Pareja

    If (HaciaColor = buf1 And HaciaColor2 = buf2) _
        Or (HaciaColor = buf2 And HaciaColor2 = buf1) Then  'Si los colores en el buffer SON los colores del buffer
    GoTo PasoRompeCicloA                                     'Rompe un ciclo (ve a PasoRompeCiclo)
    End If

    '-------------------------------------------------------------------------------------------------
    '                                      3. COMIENZA CICLO DE "MEMORIZACIÓN"

PasoComienzaCicloA:                                          'Comienza ciclo para memorizar aristas
    Posible = Posibles(HaciaColor)                          'La función "Posibles" devuelve las piezas donde podría
                                                            ' ir la pieza que está en el buffer, depende del color de PIEZA
    
    cc = 0                                                  'cc=0 para revisar la primer pieza de Posibles(), el arreglo va de 0-3 (4piezas en la cara)

PasoVaAquiA:
    On Error GoTo NoHayNadaA                             'Error si no hay nada en arreglo Posibles() 'y no hay nada en Posibles() cuando no se ha ingresado el estado del cubo
    ParejaTemp = Perteneciente(Posible(cc))             'Pareja temporal es la pareja de la 1era, 2da, 3era o 4ta pieza del arreglo "Posibles()"
        HaciaColor2Temp = centro(ParejaTemp)      'Color de la pareja temporal a donde podría ir la pieza que está en el buffer
        If HaciaColor2Temp <> HaciaColor2 Then              'Si el color de la pareja de PIEZA no es igual al color de la pareja de Posible
            cc = cc + 1                                        'Incrementa el contador en 1 para checar la siguiente pieza en "Posibles()"
            GoTo PasoVaAquiA                                     'Regresa a PasoVaAquí para revisar la siguiente pieza posible
        End If
                                                            'Si el color de la pareja de PIEZA ES igual al color de la pareja de Posible
    Aristas.Add Posible(cc)                                   'Agrega la pieza posible a la lista de Aristas memorizadas.
    PIEZA = Posible(cc)                                       'Ahora se revisará a dónde va esta nueva pieza

GoTo PasoColorDeBufferA                                      'Regresa a PasoColorDeBuffer

PasoRompeCicloA:                                             'Se llega aquí cuando el ciclo se completa (las piezas regresan al buffer)
    Set Completo = Nothing                                  'Vacía la lista de letras de aristas sin revisar
    Completo.Add a, a                                       'Agrega arista "a" (dirección: H6) a la lista de aristas sin revisar, y su nombre = a
    Completo.Add b, b
    Completo.Add c, c                                       'La primer letra lleva a la dirección, aquí c=celda h4
    Completo.Add d, d                                       'La segunda letra es el nombre de esa dirección, aquí es d.
    Completo.Add e, e
    Completo.Add f, f
    Completo.Add g, g
    Completo.Add h, h
    Completo.Add i, i
    Completo.Add j, j
    Completo.Add k, k
    Completo.Add l, l
    Completo.Add m, m
    Completo.Add n, n
    Completo.Add o, o
    Completo.Add p, p
    Completo.Add q, q
    Completo.Add r, r
    Completo.Add s, s
    Completo.Add t, t
    Completo.Add u, u
    Completo.Add v, v
    Completo.Add w, w
    Completo.Add x, x


    Cuantos = Revisados.Count                                       'Cuantos es la cantidad de aristas revisadas
    
    For zz = 1 To Cuantos
        On Error Resume Next                                        'Si ocurre error en siguiente linea (si ya se había eliminado la arista)...
                                                                 '...checa la siguiente letra en Revisados
        Completo.Remove Revisados(zz)                               'Elimina de la lista Completo las aristas que ya se revisaron,
                                                                    'Se usará para saber cuantas y cuáles piezas faltan de revisar.
    Next zz

    If Completo.Count = 0 Then                                      'Si ya no hay piezas por revisar
    GoTo TerminaMemoA                                                       'Acaba la memorización
    End If

    '-------------------------------------------------------------------------------------------------
    '                                      4. COMIENZA SIGUIENTE CICLO DE MEMORIZACIÓN

    Randomize                                                       'Inicializa el generador de números aleatorios de la función Rnd
    RandomNo = Int(Completo.Count * Rnd) + 1                        'Número random de 1 hasta el tamaño de Completo (aristas que faltan de revisar)
    
    'Cuando se comienza un ciclo nuevo, se selecciona un buffer nuevo, este buffer nuevo sí se tiene que "memorizar", a diferencia de a o m
    
    PIEZA = Completo(RandomNo)                                      'Pieza será la pieza número "RandomNo" en el arreglo "Completo" (de las que faltaban de revisar)
    buffer = PIEZA                                                  'El buffer es esa pieza random seleccionada.
    buf1 = Hacia(buffer)                                            'Color del nuevo buffer
    HaciaColor = buf1                                               'El color del nuevo buffer indica hacia dónde irá esa pieza(nuevo buffer).

    ParejaB = Perteneciente(buffer)                                 'Pareja del nuevo buffer..
    Pareja = ParejaB                                                '.. será la pareja de la pieza a analizar (buffer nuevo)
    buf2 = Hacia(ParejaB)                                           'Color de la pareja del nuevo buffer...
    HaciaColor2 = buf2                                              '...será el color de la pieza a analizar(buffer nuevo)

    Aristas.Add PIEZA                                               'Se agrega el nuevo buffer a aristas memorizadas
    Revisados.Add PIEZA                                             'Se agrega el nuevo buffer y su pareja a piezas revisadas.
    Revisados.Add Pareja
    GoTo PasoComienzaCicloA                                          'Comienza ciclo (uno nuevo :D, dentro del paso 3 )


TerminaMemoA:

    '-------------------------------------------------------------------------------------------------
    '                 5. TERMINA MEMORIZACIÓN Y ESCRIBE EN LA HOJA LAS ARISTAS MEMORIZADAS

    ConteoAristas = Aristas.Count                                   'Número de aristas memorizadas, contando las repetidas :s
    ConteoAristasT = ConteoAristas                                  'Número de aristas memorizadas, luego se reducirá si hay repetidas, y servirá
                                                                    'para saber si hay paridad o no
    zzT = 1                                                         'Servirá para decrementar la posición donde se colocará la arista memorizada
                                                                    'Si es que se repetían valores
    For zz = 1 To ConteoAristas
        Set AristaNombre = ws.Range("N" & zzT + ConteoEsquinasT)                     'Escribe arista por arista hacia abajo en la columna N
        AristaTemp2 = ws.Range(Aristas(zz)).Value                    'Guarda letra de arista actual
            
        If AristaTemp2 = AristaTemp1 Then                            'Si es igual a la anterior, zzT=zzT-1
                zzT = zzT - 2                                            'De todas formas incrementará en 1 cuando zzT=zzT+1
                ConteoAristasT = ConteoAristasT - 2                      'Hay una arista repetida, entonces se eliminan las repeticiones (2)
        Else
                AristaNombre.Value = ws.Range(Aristas(zz)).Value         'Si solo se ponia Aristas(zT), escribiría la celda y no la letra
                AristaTemp1 = ws.Range(Aristas(zz)).Value                'Guarda letra de arista actual, será la anterior cuando vuelva a entrar el For
        End If
            
        zzT = zzT + 1                                                    'Incrementa el lugar donde se colocará la siguiente arista memorizada
        
    Next zz
    
    If AristaTemp2 = AristaTemp1 Then
        Set AristaNombre = ws.Range("N" & zzT + ConteoEsquinasT)
        AristaNombre.Value = ""
    End If
    
'--------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE EJECUCIÓN
'-------------------------------------------------------------------------------------------------------------------------------------------

    'ws.Range("M1").Value = ConteoAristasT                'Escribe en M1 la cantidad de aristas "memorizadas"
    
    If (1 - (ConteoAristasT Mod 2)) = 0 Then             'Si ConteoAristasT es Impar o par (0 para impar, 1 para par)
        Paridad = "ConParidad"                              'En el método,  es impar el consiteo, existe "paridad"
        Else
        Paridad = "SinParidad"                              'En el método, si el conteo es par, no hay paridad
    End If

'aqui cambie
For CountA = 1 To ConteoAristasT

    '1 si es par, 0 si es impar
    CountAesPar = 1 - (CountA Mod 2)                                'Posición de arista actual es par o impar?

    If ws.Range("N" & CountA + ConteoEsquinasT).Value = "b" Then                      ' Algoritmos de Arista b
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Abimpar")   '"Abimpar" es el nombre de la celda en hoja wsA="Algs Modificados"
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Abpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "c" Then                 'Arista c
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Acimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Acpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "d" Then                 'Arista d
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Adimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Adpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "e" Then                 'Arista e
            ws.Range("O" & CountA + ConteoEsquinasT).Value = ""
            
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "f" Then                 'Arista f
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Afimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Afpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "g" Then                 'Arista g
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Agimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Agpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "h" Then                 'Arista h
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Ahimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Ahpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "i" Then                 'Arista i
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aiimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aipar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "j" Then                 'Arista j
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Ajimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Ajpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "k" Then                 'Arista k
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Akimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Akpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "l" Then                 'Arista l
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Alimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Alpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "m" Then                 'Arista m
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Amimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Ampar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "n" Then                 'Arista n
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Animpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Anpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "o" Then                 'Arista o
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aoimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aopar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "p" Then                 'Arista p
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Apimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Appar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "q" Then                 'Arista q
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aqimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aqpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "r" Then                 'Arista r
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Arimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Arpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "s" Then                 'Arista s
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Asimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aspar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "t" Then                 'Arista t
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Atimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Atpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "u" Then                 'Arista u
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Auimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aupar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "v" Then                 'Arista v
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Avimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Avpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "w" Then                 'Arista w
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Awimpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Awpar")
        End If
        
     ElseIf ws.Range("N" & CountA + ConteoEsquinasT).Value = "x" Then                 'Arista x
        If CountAesPar = 0 Then
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Aximpar")
        Else
            ws.Range("O" & CountA + ConteoEsquinasT).Value = wsA.Range("Axpar")
        End If
     End If
    
     'If CountA = ConteoAristasT And Paridad = "ConParidad" Then       'Si ya se colocaron todos los algoritmos de aristas "memorizadas"
     
     If (CountA = ConteoAristasT) And (Paridad = "ConParidad") Then    'Si ya se colocaron todos los algoritmos de aristas "memorizadas"
                                                                        'y si hay paridad
        ws.Range("O" & CountA + ConteoEsquinasT + 1).Value = wsA.Range("Paridad")   'Colocar abajo el algoritmo de paridad
        ws.Range("N" & CountA + ConteoEsquinasT + 1).Value = " (Paridad) "           'Etiqueda " (Paridad) "
     Else
     End If

Next CountA
    
    ws.Range("R2").Formula = "=CONCAT(O:O)"                   'Escribe el algoritmo entero para resolver el cubo en celda R2
    ws.Range("R2").Copy
    ws.Range("R2").PasteSpecial xlPasteValues                 'Lo pega ahí mismo para que aparezca como valores y no como fórmula.
    ws.Range("A1").Select
    
    GoTo FinalizarA

    '-------------------------------------------------------------------------------------------------
    '                    Si no se ingresó el estado inicial del cubo o es incorrecto
    
NoHayNadaA:
        MsgBox "Ingrese antes el estado inicial del cubo", vbExclamation, "ERROR"

FinalizarA:
    
    
    '-------------------------------------------------------------------------------------------------
    '                    Conteo de giros necesarios para resolver el cubo con éste método

Dim Algoritmo As String
Dim GirosEnAlgoritmo As Long
Dim GirosRepetidos As Long


Algoritmo = Range("R2").Value
GirosEnAlgoritmo = Len(Algoritmo) - Len(Application.WorksheetFunction.Substitute(Algoritmo, " ", ""))
GirosRepetidos = Len(Algoritmo) - Len(Application.WorksheetFunction.Substitute(Algoritmo, "2", ""))
GirosTotales = GirosRepetidos + GirosEnAlgoritmo
Range("A11").Value = GirosTotales
Range("B11").Value = "Giros de 90°"

Range("A12").Value = GirosTotales / 3 / 60
Range("B12").Value = "Minutos, si se hacen 3 giros por segundo"

End Sub

Private Sub Worksheet_SelectionChange(ByVal Target As Range)
'----------------------------------------------------------------
'                Colocar estado inicial
'----------------------------------------------------------------
    If Selection.Count = 1 Then
    
        If Not Intersect(Target, Range("A4:L12")) Is Nothing Then
            ActiveCell.Interior.Color = ColorBoton                      'Coloca el color del boton antes presionado en la celda activa (seleccionada)
            
            Range("A4:F6").Interior.Color = RGB(255, 255, 255)          'No deja colocar color afuera del cubo
            Range("J4:L6").Interior.Color = RGB(255, 255, 255)          'No deja colocar color afuera del cubo
            Range("A10:F12").Interior.Color = RGB(255, 255, 255)        'No deja colocar color afuera del cubo
            Range("J10:L12").Interior.Color = RGB(255, 255, 255)        'No deja colocar color afuera del cubo
            
            Range("H5").Interior.Color = RGB(255, 255, 255)             'Mantiene el color del centro
            Range("B8").Interior.Color = RGB(0, 112, 192)               'Mantiene el color del centro
            Range("E8").Interior.Color = RGB(255, 152, 1)               'Mantiene el color del centro
            Range("H8").Interior.Color = RGB(0, 176, 80)                'Mantiene el color del centro
            Range("H11").Interior.Color = RGB(255, 255, 0)              'Mantiene el color del centro
            Range("k8").Interior.Color = RGB(255, 0, 0)                 'Mantiene el color del centro
        End If
        
    End If

End Sub