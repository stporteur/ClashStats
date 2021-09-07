using ClashData;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBusiness.Tests
{
    public class AutofacFactoryTests
    {
        [Test]
        public void Should_instanciate_static_object_when_calling_it_for_first_time()
        {
            Check.That(AutofacFactory.Instance).IsNotNull();
        }

        [Test]
        public void Should_get_same_instance_when_each_time_its_called()
        {
            var instance1 = AutofacFactory.Instance;
            var instance2 = AutofacFactory.Instance;
            var instance3 = AutofacFactory.Instance;

            Check.That(AutofacFactory.Instance).IsSameReferenceAs(instance1);
            Check.That(AutofacFactory.Instance).IsSameReferenceAs(instance2);
            Check.That(AutofacFactory.Instance).IsSameReferenceAs(instance3);
        }

        [Test]
        public void Should_get_instance_from_dal()
        {
            Check.That(AutofacFactory.Instance.GetInstance<IWarriorDal>()).IsNotNull();
        }

        [Test]
        public void Should_get_instance_from_business()
        {
            Check.That(AutofacFactory.Instance.GetInstance<IWarriorManagement>()).IsNotNull();
        }
    }
}
