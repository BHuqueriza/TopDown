/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       02/08/2016 00:16
================================================================*/

using UnityEngine;

public interface IDamageable
{
    void TakeHit(float damage, RaycastHit hit);
    void TakeDamage(float damage);
}