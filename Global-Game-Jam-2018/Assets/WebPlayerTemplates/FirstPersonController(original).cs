u s i n g   S y s t e m ;  
 u s i n g   U n i t y E n g i n e ;  
 u s i n g   U n i t y S t a n d a r d A s s e t s . C r o s s P l a t f o r m I n p u t ;  
 u s i n g   U n i t y S t a n d a r d A s s e t s . U t i l i t y ;  
 u s i n g   R a n d o m   =   U n i t y E n g i n e . R a n d o m ;  
  
 n a m e s p a c e   U n i t y S t a n d a r d A s s e t s . C h a r a c t e r s . F i r s t P e r s o n  
 {  
         [ R e q u i r e C o m p o n e n t ( t y p e o f   ( C h a r a c t e r C o n t r o l l e r ) ) ]  
         [ R e q u i r e C o m p o n e n t ( t y p e o f   ( A u d i o S o u r c e ) ) ]  
         p u b l i c   c l a s s   F i r s t P e r s o n C o n t r o l l e r   :   M o n o B e h a v i o u r  
         {  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   b o o l   m _ I s W a l k i n g ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ W a l k S p e e d ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ R u n S p e e d ;  
                 [ S e r i a l i z e F i e l d ]   [ R a n g e ( 0 f ,   1 f ) ]   p r i v a t e   f l o a t   m _ R u n s t e p L e n g h t e n ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ J u m p S p e e d ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ S t i c k T o G r o u n d F o r c e ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ G r a v i t y M u l t i p l i e r ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   M o u s e L o o k   m _ M o u s e L o o k ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   b o o l   m _ U s e F o v K i c k ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   F O V K i c k   m _ F o v K i c k   =   n e w   F O V K i c k ( ) ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   b o o l   m _ U s e H e a d B o b ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   C u r v e C o n t r o l l e d B o b   m _ H e a d B o b   =   n e w   C u r v e C o n t r o l l e d B o b ( ) ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   L e r p C o n t r o l l e d B o b   m _ J u m p B o b   =   n e w   L e r p C o n t r o l l e d B o b ( ) ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   f l o a t   m _ S t e p I n t e r v a l ;  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   A u d i o C l i p [ ]   m _ F o o t s t e p S o u n d s ;         / /   a n   a r r a y   o f   f o o t s t e p   s o u n d s   t h a t   w i l l   b e   r a n d o m l y   s e l e c t e d   f r o m .  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   A u d i o C l i p   m _ J u m p S o u n d ;                       / /   t h e   s o u n d   p l a y e d   w h e n   c h a r a c t e r   l e a v e s   t h e   g r o u n d .  
                 [ S e r i a l i z e F i e l d ]   p r i v a t e   A u d i o C l i p   m _ L a n d S o u n d ;                       / /   t h e   s o u n d   p l a y e d   w h e n   c h a r a c t e r   t o u c h e s   b a c k   o n   g r o u n d .  
  
                 p r i v a t e   C a m e r a   m _ C a m e r a ;  
                 p r i v a t e   b o o l   m _ J u m p ;  
                 p r i v a t e   f l o a t   m _ Y R o t a t i o n ;  
                 p r i v a t e   V e c t o r 2   m _ I n p u t ;  
                 p r i v a t e   V e c t o r 3   m _ M o v e D i r   =   V e c t o r 3 . z e r o ;  
                 p r i v a t e   C h a r a c t e r C o n t r o l l e r   m _ C h a r a c t e r C o n t r o l l e r ;  
                 p r i v a t e   C o l l i s i o n F l a g s   m _ C o l l i s i o n F l a g s ;  
                 p r i v a t e   b o o l   m _ P r e v i o u s l y G r o u n d e d ;  
                 p r i v a t e   V e c t o r 3   m _ O r i g i n a l C a m e r a P o s i t i o n ;  
                 p r i v a t e   f l o a t   m _ S t e p C y c l e ;  
                 p r i v a t e   f l o a t   m _ N e x t S t e p ;  
                 p r i v a t e   b o o l   m _ J u m p i n g ;  
                 p r i v a t e   A u d i o S o u r c e   m _ A u d i o S o u r c e ;  
  
                 / /   U s e   t h i s   f o r   i n i t i a l i z a t i o n  
                 p r i v a t e   v o i d   S t a r t ( )  
                 {  
                         m _ C h a r a c t e r C o n t r o l l e r   =   G e t C o m p o n e n t < C h a r a c t e r C o n t r o l l e r > ( ) ;  
                         m _ C a m e r a   =   C a m e r a . m a i n ;  
                         m _ O r i g i n a l C a m e r a P o s i t i o n   =   m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n ;  
                         m _ F o v K i c k . S e t u p ( m _ C a m e r a ) ;  
                         m _ H e a d B o b . S e t u p ( m _ C a m e r a ,   m _ S t e p I n t e r v a l ) ;  
                         m _ S t e p C y c l e   =   0 f ;  
                         m _ N e x t S t e p   =   m _ S t e p C y c l e / 2 f ;  
                         m _ J u m p i n g   =   f a l s e ;  
                         m _ A u d i o S o u r c e   =   G e t C o m p o n e n t < A u d i o S o u r c e > ( ) ;  
 	 	 	 m _ M o u s e L o o k . I n i t ( t r a n s f o r m   ,   m _ C a m e r a . t r a n s f o r m ) ;  
                 }  
  
  
                 / /   U p d a t e   i s   c a l l e d   o n c e   p e r   f r a m e  
                 p r i v a t e   v o i d   U p d a t e ( )  
                 {  
                         R o t a t e V i e w ( ) ;  
                         / /   t h e   j u m p   s t a t e   n e e d s   t o   r e a d   h e r e   t o   m a k e   s u r e   i t   i s   n o t   m i s s e d  
                         i f   ( ! m _ J u m p )  
                         {  
                                 m _ J u m p   =   C r o s s P l a t f o r m I n p u t M a n a g e r . G e t B u t t o n D o w n ( " J u m p " ) ;  
                         }  
  
                         i f   ( ! m _ P r e v i o u s l y G r o u n d e d   & &   m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d )  
                         {  
                                 S t a r t C o r o u t i n e ( m _ J u m p B o b . D o B o b C y c l e ( ) ) ;  
                                 P l a y L a n d i n g S o u n d ( ) ;  
                                 m _ M o v e D i r . y   =   0 f ;  
                                 m _ J u m p i n g   =   f a l s e ;  
                         }  
                         i f   ( ! m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d   & &   ! m _ J u m p i n g   & &   m _ P r e v i o u s l y G r o u n d e d )  
                         {  
                                 m _ M o v e D i r . y   =   0 f ;  
                         }  
  
                         m _ P r e v i o u s l y G r o u n d e d   =   m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d ;  
                 }  
  
  
                 p r i v a t e   v o i d   P l a y L a n d i n g S o u n d ( )  
                 {  
                         m _ A u d i o S o u r c e . c l i p   =   m _ L a n d S o u n d ;  
                         m _ A u d i o S o u r c e . P l a y ( ) ;  
                         m _ N e x t S t e p   =   m _ S t e p C y c l e   +   . 5 f ;  
                 }  
  
  
                 p r i v a t e   v o i d   F i x e d U p d a t e ( )  
                 {  
                         f l o a t   s p e e d ;  
                         G e t I n p u t ( o u t   s p e e d ) ;  
                         / /   a l w a y s   m o v e   a l o n g   t h e   c a m e r a   f o r w a r d   a s   i t   i s   t h e   d i r e c t i o n   t h a t   i t   b e i n g   a i m e d   a t  
                         V e c t o r 3   d e s i r e d M o v e   =   t r a n s f o r m . f o r w a r d * m _ I n p u t . y   +   t r a n s f o r m . r i g h t * m _ I n p u t . x ;  
  
                         / /   g e t   a   n o r m a l   f o r   t h e   s u r f a c e   t h a t   i s   b e i n g   t o u c h e d   t o   m o v e   a l o n g   i t  
                         R a y c a s t H i t   h i t I n f o ;  
                         P h y s i c s . S p h e r e C a s t ( t r a n s f o r m . p o s i t i o n ,   m _ C h a r a c t e r C o n t r o l l e r . r a d i u s ,   V e c t o r 3 . d o w n ,   o u t   h i t I n f o ,  
                                                               m _ C h a r a c t e r C o n t r o l l e r . h e i g h t / 2 f ,   P h y s i c s . A l l L a y e r s ,   Q u e r y T r i g g e r I n t e r a c t i o n . I g n o r e ) ;  
                         d e s i r e d M o v e   =   V e c t o r 3 . P r o j e c t O n P l a n e ( d e s i r e d M o v e ,   h i t I n f o . n o r m a l ) . n o r m a l i z e d ;  
  
                         m _ M o v e D i r . x   =   d e s i r e d M o v e . x * s p e e d ;  
                         m _ M o v e D i r . z   =   d e s i r e d M o v e . z * s p e e d ;  
  
  
                         i f   ( m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d )  
                         {  
                                 m _ M o v e D i r . y   =   - m _ S t i c k T o G r o u n d F o r c e ;  
  
                                 i f   ( m _ J u m p )  
                                 {  
                                         m _ M o v e D i r . y   =   m _ J u m p S p e e d ;  
                                         P l a y J u m p S o u n d ( ) ;  
                                         m _ J u m p   =   f a l s e ;  
                                         m _ J u m p i n g   =   t r u e ;  
                                 }  
                         }  
                         e l s e  
                         {  
                                 m _ M o v e D i r   + =   P h y s i c s . g r a v i t y * m _ G r a v i t y M u l t i p l i e r * T i m e . f i x e d D e l t a T i m e ;  
                         }  
                         m _ C o l l i s i o n F l a g s   =   m _ C h a r a c t e r C o n t r o l l e r . M o v e ( m _ M o v e D i r * T i m e . f i x e d D e l t a T i m e ) ;  
  
                         P r o g r e s s S t e p C y c l e ( s p e e d ) ;  
                         U p d a t e C a m e r a P o s i t i o n ( s p e e d ) ;  
  
                         m _ M o u s e L o o k . U p d a t e C u r s o r L o c k ( ) ;  
                 }  
  
  
                 p r i v a t e   v o i d   P l a y J u m p S o u n d ( )  
                 {  
                         m _ A u d i o S o u r c e . c l i p   =   m _ J u m p S o u n d ;  
                         m _ A u d i o S o u r c e . P l a y ( ) ;  
                 }  
  
  
                 p r i v a t e   v o i d   P r o g r e s s S t e p C y c l e ( f l o a t   s p e e d )  
                 {  
                         i f   ( m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y . s q r M a g n i t u d e   >   0   & &   ( m _ I n p u t . x   ! =   0   | |   m _ I n p u t . y   ! =   0 ) )  
                         {  
                                 m _ S t e p C y c l e   + =   ( m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y . m a g n i t u d e   +   ( s p e e d * ( m _ I s W a l k i n g   ?   1 f   :   m _ R u n s t e p L e n g h t e n ) ) ) *  
                                                           T i m e . f i x e d D e l t a T i m e ;  
                         }  
  
                         i f   ( ! ( m _ S t e p C y c l e   >   m _ N e x t S t e p ) )  
                         {  
                                 r e t u r n ;  
                         }  
  
                         m _ N e x t S t e p   =   m _ S t e p C y c l e   +   m _ S t e p I n t e r v a l ;  
  
                         P l a y F o o t S t e p A u d i o ( ) ;  
                 }  
  
  
                 p r i v a t e   v o i d   P l a y F o o t S t e p A u d i o ( )  
                 {  
                         i f   ( ! m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d )  
                         {  
                                 r e t u r n ;  
                         }  
                         / /   p i c k   &   p l a y   a   r a n d o m   f o o t s t e p   s o u n d   f r o m   t h e   a r r a y ,  
                         / /   e x c l u d i n g   s o u n d   a t   i n d e x   0  
                         i n t   n   =   R a n d o m . R a n g e ( 1 ,   m _ F o o t s t e p S o u n d s . L e n g t h ) ;  
                         m _ A u d i o S o u r c e . c l i p   =   m _ F o o t s t e p S o u n d s [ n ] ;  
                         m _ A u d i o S o u r c e . P l a y O n e S h o t ( m _ A u d i o S o u r c e . c l i p ) ;  
                         / /   m o v e   p i c k e d   s o u n d   t o   i n d e x   0   s o   i t ' s   n o t   p i c k e d   n e x t   t i m e  
                         m _ F o o t s t e p S o u n d s [ n ]   =   m _ F o o t s t e p S o u n d s [ 0 ] ;  
                         m _ F o o t s t e p S o u n d s [ 0 ]   =   m _ A u d i o S o u r c e . c l i p ;  
                 }  
  
  
                 p r i v a t e   v o i d   U p d a t e C a m e r a P o s i t i o n ( f l o a t   s p e e d )  
                 {  
                         V e c t o r 3   n e w C a m e r a P o s i t i o n ;  
                         i f   ( ! m _ U s e H e a d B o b )  
                         {  
                                 r e t u r n ;  
                         }  
                         i f   ( m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y . m a g n i t u d e   >   0   & &   m _ C h a r a c t e r C o n t r o l l e r . i s G r o u n d e d )  
                         {  
                                 m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n   =  
                                         m _ H e a d B o b . D o H e a d B o b ( m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y . m a g n i t u d e   +  
                                                                             ( s p e e d * ( m _ I s W a l k i n g   ?   1 f   :   m _ R u n s t e p L e n g h t e n ) ) ) ;  
                                 n e w C a m e r a P o s i t i o n   =   m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n ;  
                                 n e w C a m e r a P o s i t i o n . y   =   m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n . y   -   m _ J u m p B o b . O f f s e t ( ) ;  
                         }  
                         e l s e  
                         {  
                                 n e w C a m e r a P o s i t i o n   =   m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n ;  
                                 n e w C a m e r a P o s i t i o n . y   =   m _ O r i g i n a l C a m e r a P o s i t i o n . y   -   m _ J u m p B o b . O f f s e t ( ) ;  
                         }  
                         m _ C a m e r a . t r a n s f o r m . l o c a l P o s i t i o n   =   n e w C a m e r a P o s i t i o n ;  
                 }  
  
  
                 p r i v a t e   v o i d   G e t I n p u t ( o u t   f l o a t   s p e e d )  
                 {  
                         / /   R e a d   i n p u t  
                         f l o a t   h o r i z o n t a l   =   C r o s s P l a t f o r m I n p u t M a n a g e r . G e t A x i s ( " H o r i z o n t a l " ) ;  
                         f l o a t   v e r t i c a l   =   C r o s s P l a t f o r m I n p u t M a n a g e r . G e t A x i s ( " V e r t i c a l " ) ;  
  
                         b o o l   w a s w a l k i n g   =   m _ I s W a l k i n g ;  
  
 # i f   ! M O B I L E _ I N P U T  
                         / /   O n   s t a n d a l o n e   b u i l d s ,   w a l k / r u n   s p e e d   i s   m o d i f i e d   b y   a   k e y   p r e s s .  
                         / /   k e e p   t r a c k   o f   w h e t h e r   o r   n o t   t h e   c h a r a c t e r   i s   w a l k i n g   o r   r u n n i n g  
                         m _ I s W a l k i n g   =   ! I n p u t . G e t K e y ( K e y C o d e . L e f t S h i f t ) ;  
 # e n d i f  
                         / /   s e t   t h e   d e s i r e d   s p e e d   t o   b e   w a l k i n g   o r   r u n n i n g  
                         s p e e d   =   m _ I s W a l k i n g   ?   m _ W a l k S p e e d   :   m _ R u n S p e e d ;  
                         m _ I n p u t   =   n e w   V e c t o r 2 ( h o r i z o n t a l ,   v e r t i c a l ) ;  
  
                         / /   n o r m a l i z e   i n p u t   i f   i t   e x c e e d s   1   i n   c o m b i n e d   l e n g t h :  
                         i f   ( m _ I n p u t . s q r M a g n i t u d e   >   1 )  
                         {  
                                 m _ I n p u t . N o r m a l i z e ( ) ;  
                         }  
  
                         / /   h a n d l e   s p e e d   c h a n g e   t o   g i v e   a n   f o v   k i c k  
                         / /   o n l y   i f   t h e   p l a y e r   i s   g o i n g   t o   a   r u n ,   i s   r u n n i n g   a n d   t h e   f o v k i c k   i s   t o   b e   u s e d  
                         i f   ( m _ I s W a l k i n g   ! =   w a s w a l k i n g   & &   m _ U s e F o v K i c k   & &   m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y . s q r M a g n i t u d e   >   0 )  
                         {  
                                 S t o p A l l C o r o u t i n e s ( ) ;  
                                 S t a r t C o r o u t i n e ( ! m _ I s W a l k i n g   ?   m _ F o v K i c k . F O V K i c k U p ( )   :   m _ F o v K i c k . F O V K i c k D o w n ( ) ) ;  
                         }  
                 }  
  
  
                 p r i v a t e   v o i d   R o t a t e V i e w ( )  
                 {  
                         m _ M o u s e L o o k . L o o k R o t a t i o n   ( t r a n s f o r m ,   m _ C a m e r a . t r a n s f o r m ) ;  
                 }  
  
  
                 p r i v a t e   v o i d   O n C o n t r o l l e r C o l l i d e r H i t ( C o n t r o l l e r C o l l i d e r H i t   h i t )  
                 {  
                         R i g i d b o d y   b o d y   =   h i t . c o l l i d e r . a t t a c h e d R i g i d b o d y ;  
                         / / d o n t   m o v e   t h e   r i g i d b o d y   i f   t h e   c h a r a c t e r   i s   o n   t o p   o f   i t  
                         i f   ( m _ C o l l i s i o n F l a g s   = =   C o l l i s i o n F l a g s . B e l o w )  
                         {  
                                 r e t u r n ;  
                         }  
  
                         i f   ( b o d y   = =   n u l l   | |   b o d y . i s K i n e m a t i c )  
                         {  
                                 r e t u r n ;  
                         }  
                         b o d y . A d d F o r c e A t P o s i t i o n ( m _ C h a r a c t e r C o n t r o l l e r . v e l o c i t y * 0 . 1 f ,   h i t . p o i n t ,   F o r c e M o d e . I m p u l s e ) ;  
                 }  
         }  
 }  
 