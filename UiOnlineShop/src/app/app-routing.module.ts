import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';

const routes : Routes = [
    {
        path : 'productos',
        component : ProductsComponent
    },
    {
        path : 'admin', loadChildren: ()=> import('./admin/admin.module').then(m=> m.AdminModule)
    }
]

@NgModule({
    imports : [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}